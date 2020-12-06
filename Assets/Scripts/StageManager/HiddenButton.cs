using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HiddenButton : MonoBehaviour
{
    public bool isImage = false;
    public bool isButton = false;

    public PlayerController player;
    public GameObject road;
    public GameObject light;
    public SpriteRenderer sprite;
    public TextController text;

    public string NPCname;
    public TextAsset textFile_image;
    public TextAsset textFile_button;

    private bool isTouch = false;

    private int timeline = 0;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        sprite = GetComponent<SpriteRenderer>();
        text = GameObject.Find("NPCTalking").GetComponent<TextController>();
        light = GameObject.Find("light");
        road.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 0);

        timeline = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(isTouch)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (!isImage)
                {
                    if(!text.isMessage)
                    {
                        if (timeline == 0)
                        {
                            GameManager.gameManager.grandMother_num++;
                            timeline = 1;
                            player.isEvent = true; //플레이어가 정지함
                            text.isMessage = true; //메세지를 출력함
                            text.NPCname.text = NPCname;
                            text.textFile = textFile_image;
                        }
                        else if(timeline == 1)
                        {
                            isImage = true;
                            sprite.color = new Color(0, 0, 0, 0);
                        }
                    }
                    
                }
                else if (!GameManager.gameManager.grandMother_light)
                {
                    if (!text.isMessage)
                    {
                        GameManager.gameManager.grandMother_light = true;
                        GameManager.gameManager.grandMother_num++;

                        player.isEvent = true; //플레이어가 정지함
                        text.isMessage = true; //메세지를 출력함
                        text.NPCname.text = NPCname;
                        text.textFile = textFile_button;
                    }
                }
            }
        }

        if(GameManager.gameManager.grandMother_light)
        {
            road.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
            road.GetComponent<BoxCollider2D>().isTrigger = true;
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
