using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MoveScene : MonoBehaviour
{
    public GameObject player;
    public Animator transition;
    
    public string transferMap; //이동할 맵
    public float transitionTime = 1f;

    public Image image;
    
    private bool isTouch = false;
    void Start()
    {
        image = GetComponentInChildren<Image>();
        player = GameObject.FindGameObjectWithTag("Player");

        if (SceneManager.GetActiveScene().name.Equals("Rocket_Unlocked") && GameManager.gameManager.previousScene.Equals("FirstStage")) //이전 씬과 현재 씬에 따라 페이드 인/아웃의 색깔 결정
        {
            image.color = Color.white;
        }
        else if (SceneManager.GetActiveScene().name.Equals("FirstStage") && GameManager.gameManager.previousScene.Equals("Rocket_Unlocked"))
        {
            image.color = Color.white;
        }
        else if (SceneManager.GetActiveScene().name.Equals("Rocket_Locked") && GameManager.gameManager.previousScene.Equals("FirstStage"))
        {
            image.color = Color.white;
        }
        else if (SceneManager.GetActiveScene().name.Equals("FirstStage") && GameManager.gameManager.previousScene.Equals("Rocket_Locked"))
        {
            image.color = Color.white;
        }
        else
        {
            image.color = Color.black;
        }
    }
    
    void Update()
    {
        if(isTouch)
        {
            if(Input.GetKeyUp(KeyCode.Space)) //씬 변경
            {
                player.GetComponent<PlayerController>().isEvent = true; //씬 변경될 때에는 움직이지 않게 함.
                LoadNextLevel();
            }
        }
    }
    
    public void LoadNextLevel()
    {
        StartCoroutine(LoadLevel());
    }
    
    IEnumerator LoadLevel()
    {
        if (SceneManager.GetActiveScene().name.Equals("Rocket_Unlocked") && transferMap.Equals("FirstStage")) //이전 씬과 현재 씬에 따라 페이드 인/아웃의 색깔 결정
        {
            image.color = Color.white;
        }
        else if(SceneManager.GetActiveScene().name.Equals("FirstStage") && transferMap.Equals("Rocket_Unlocked"))
        {
            image.color = Color.white;
        }
        else if (SceneManager.GetActiveScene().name.Equals("Rocket_Locked") && transferMap.Equals("FirstStage"))
        {
            image.color = Color.white;
        }
        else if (SceneManager.GetActiveScene().name.Equals("FirstStage") && transferMap.Equals("Rocket_Locked"))
        {
            image.color = Color.white;
        }
        else
        {
            image.color = Color.black;
        }

        //play animation
        transition.SetTrigger("Start"); //페이드 아웃
        
        //wait
        yield return new WaitForSeconds(transitionTime); //1초후 씬 이동

        //load scene
        GameManager.gameManager.grandMother_num = 0;
        GameManager.gameManager.previousScene = SceneManager.GetActiveScene().name; //이전 씬 정보를 갱신
        GameManager.gameManager.presentScene = transferMap; //현재 씬 정보를 갱신
        SceneManager.LoadScene(transferMap); //씬 변경
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player")
        {
            isTouch = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player")
        {
            isTouch = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            isTouch = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            isTouch = false;
        }
    }
}
