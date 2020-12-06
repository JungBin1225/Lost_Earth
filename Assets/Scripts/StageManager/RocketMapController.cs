using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketMapController : MonoBehaviour
{
    private int isMoved = 0;

    public GameObject player;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        GameManager.gameManager.O2 = 100;
        GameManager.gameManager.temp = 30.0f;

        isMove();

        if (GameManager.gameManager.previousScene.Equals("FirstStage")) //이전 씬에 따라 생성위치 변경
        {
            if (isMoved == 0) //씬 변경되고 나서 움직이지 않았을 때
            {
                player.transform.position = new Vector3(-4.5f, 1, 0);
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
