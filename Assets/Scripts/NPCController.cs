using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCController : MonoBehaviour
{
    public PlayerController player;
    public TextController textController;
    public bool isTouch = false;

    public string NPCname;
    public TextAsset textFile;

    public bool first = true;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        textController = GameObject.Find("NPCTalking").GetComponent<TextController>();
    }

    void Update()
    {
        if(isTouch)
        {
            if (Input.GetKeyUp(KeyCode.Space))
            {
                if(first)
                {
                    GameManager.gameManager.grandMother_num++;
                    first = false;
                }
                player.isEvent = true; //플레이어가 정지함
                textController.isMessage = true; //메세지를 출력함
                textController.NPCname.text = NPCname;
                textController.textFile = textFile;
            }
        }
    }

    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "Player")
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
