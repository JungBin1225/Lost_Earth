using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrandMotherRoom : MonoBehaviour
{
    public GameObject player;
    public Camera cam;
    public TextController textController;

    public string NPCname;
    public TextAsset textFile_notClear;
    public TextAsset textFile_allClear;
    public TextAsset textFile_firstLook;

    public bool allClear = false;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        cam = Camera.main;
        textController = GameObject.Find("NPCTalking").GetComponent<TextController>();
    }

    
    void Update()
    {
        if (GameManager.gameManager.previousScene.Equals("Rocket_Locked"))
        {
            GameManager.gameManager.grandMother_num = 7;
            allClear = true;
        }

        if (player.transform.position.x < -8)
        {
            cam.transform.position = new Vector3(player.transform.position.x, 0, -10);
        }
        else
        {
            cam.transform.position = new Vector3(1, 0, -10);
        }

        if(player.transform.position.x < -5)
        {
            if(GameManager.gameManager.grandMother_num < 8)
            {
                player.GetComponent<PlayerController>().isEvent = true; //플레이어가 정지함
                textController.isMessage = true; //메세지를 출력함
                textController.NPCname.text = NPCname;
                textController.textFile = textFile_notClear;
                player.transform.position = new Vector3(-5, player.transform.position.y, player.transform.position.z);
            }
            else if(GameManager.gameManager.grandMother_num >= 8 && allClear == false)
            {
                allClear = true;
                player.GetComponent<PlayerController>().isEvent = true; //플레이어가 정지함
                textController.isMessage = true; //메세지를 출력함
                textController.NPCname.text = NPCname;
                textController.textFile = textFile_allClear;
                allClear = true;
            }
        }

        if(player.transform.position.x < -35)
        {
            if(!GameManager.gameManager.first_look)
            {
                GameManager.gameManager.first_look = true;
                textController.isMessage = true; //메세지를 출력함
                textController.NPCname.text = NPCname;
                textController.textFile = textFile_firstLook;
            }
        }
    }
}
