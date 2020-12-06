using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRoomController : MonoBehaviour
{
    public MoveScene moveScene;
    public PlayerRoomDoorController door;
    public NPCController text;

    public bool isItem = false;


    void Start()
    {
        moveScene = GameObject.Find("Door").GetComponent<MoveScene>();
        text = GameObject.Find("Door").GetComponent<NPCController>();
        door = GameObject.Find("door animation").GetComponent<PlayerRoomDoorController>();
    }

    
    void Update()
    {
        if(GameManager.gameManager.itemNum.Contains(2) && GameManager.gameManager.itemNum.Contains(3) && GameManager.gameManager.foodBox)
        {
            text.enabled = false;
            moveScene.enabled = true;
            door.enabled = true;
        }
        else
        {
            text.enabled = true;
            moveScene.enabled = false;
            door.enabled = false;
        }
    }
}
