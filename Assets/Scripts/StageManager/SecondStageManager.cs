using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondStageManager : MonoBehaviour
{
    private int isMoved = 0;

    public MoveScene scene;
    public GameObject player;

    public List<bool> isCharge = new List<bool> { false, false, false };

    void Start()
    {
        scene = GameObject.Find("Teleport").GetComponent<MoveScene>();
        player = GameObject.FindGameObjectWithTag("Player");
        isCharge = new List<bool> { false, false, false };
    }

    void Update()
    {
        isMove();

        if (GameManager.gameManager.previousScene.Equals("ShelterIn_2")) //이전 씬에 따라 생성위치 변경
        {
            if (isMoved == 0) //씬 변경되고 나서 움직이지 않았을 때
            {
                player.transform.position = new Vector3(6.2f, -5.5f, 0);
            }
        }
        else if (GameManager.gameManager.previousScene.Equals("ShelterIn_3")) //이전 씬에 따라 생성위치 변경
        {
            if (isMoved == 0) //씬 변경되고 나서 움직이지 않았을 때
            {
                player.transform.position = new Vector3(-63f, 9.5f, 0);
            }
        }

        if (GameManager.gameManager.first_Lock[0] && GameManager.gameManager.first_Lock[1] && GameManager.gameManager.first_Lock[2] && GameManager.gameManager.second_Lock[0] && GameManager.gameManager.second_Lock[1] && GameManager.gameManager.second_Lock[2])
        {
            scene.transferMap = "Rocket_Unlocked";
        }

        if (GameManager.gameManager.O2 > 0)
        {
            if (!isCharge[0] && !isCharge[1]) //산소충전이 안되고 있으면 산소 감소
            {
                GameManager.gameManager.O2 -= 1.5f * Time.deltaTime;
            }
        }

        GameManager.gameManager.temp += 0.5f * Time.deltaTime;
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
