using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCController : MonoBehaviour
{
    public PlayerController player;
    public TextController textController;
    public bool isTouch = false;

    public string NPCname;
    public string NPCtalk;

    void Start()
    {
        player = GameObject.Find("Player").GetComponent<PlayerController>();
        textController = GameObject.Find("NPCTalking").GetComponent<TextController>();
    }

    void Update()
    {
        if(isTouch)
        {
            if (Input.GetKeyUp(KeyCode.Space))
            {
                player.isEvent = true;
                textController.NPCname.text = NPCname;
                textController.talkText = NPCtalk;
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
            isTouch = true;
        }
    }
}
