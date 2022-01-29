using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManagerLogic : MonoBehaviour
{   
    public int totalItemCnt;
    public int stage;
    public Text stageUI;
    public Text playerUI;

    void Awake() {
        stageUI.text="/"+totalItemCnt;    
    }
    public void GetItem(int count) {
        playerUI.text=count.ToString();
    }
    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "Player"){
            SceneManager.LoadScene(stage);
        }
    }
}
