using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerBall : MonoBehaviour
{   
    Rigidbody rigid;
    AudioSource audio;
    int jumpcnt;
    public int score;
    public GameManagerLogic manager;
    public float jumpPower;
    void Awake(){
        score=0;
        jumpcnt=0;
        rigid=GetComponent<Rigidbody>();
        audio = GetComponent<AudioSource>();
    }
    // Update is called once per frame

    void Update(){
        if(Input.GetButtonDown("Jump") && jumpcnt < 2){
            jumpcnt++;
            rigid.AddForce(new Vector3(0,jumpPower,0),ForceMode.Impulse);
        }
    }
    void FixedUpdate()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        
        rigid.AddForce(new Vector3(h,0,v), ForceMode.Impulse);
    }

    void OnCollisionEnter(Collision collision) {
        if(collision.gameObject.tag=="Floor"){
            jumpcnt=0;
        }
    }

    void OnTriggerEnter(Collider other) {
        if(other.tag=="Item"){
            score++;
            audio.Play();
            other.gameObject.SetActive(false);
            manager.GetItem(score);
        }
        else if(other.tag=="Finish"){
            if(score == manager.totalItemCnt){
                //clear
                SceneManager.LoadScene(manager.stage+1);
            }
            else{
               //restart
                SceneManager.LoadScene(manager.stage);
            }
        }
    }
}
