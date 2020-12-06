using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class B13Controller : MonoBehaviour
{
    private int isMoved = 0;

    public GameObject player;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }


    void Update()
    {
        isMove();

        if (GameManager.gameManager.previousScene.Equals("Hallway_B43")) //이전 씬에 따라 생성위치 변경
        {
            if (isMoved == 0) //씬 변경되고 나서 움직이지 않았을 때
            {
                player.transform.position = new Vector3(-12f, 0f, 0);
            }
        }
    }

    void isMove()
    {
        if (isMoved != 1)
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                isMoved = 1;
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                isMoved = 1;
            }
            else if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                isMoved = 1;
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                isMoved = 1;
            }
        }
    }
}
