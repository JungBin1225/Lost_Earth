using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstStageManager : MonoBehaviour
{
    private int isMoved = 0;

    public MoveScene scene;
    public GameObject player;
    public List<bool> isCharge = new List<bool> { false, false, false }; //3개의 산소충전기를 구분해놓음

    void Start()
    {
        scene = GameObject.Find("Teleport").GetComponent<MoveScene>();
        player = GameObject.FindGameObjectWithTag("Player");
        isCharge = new List<bool> { false, false, false };
    }

    void Update()
    {
        isMove();

        if(GameManager.gameManager.previousScene.Equals("ShelterIn")) //이전 씬에 따라 생성위치 변경
        {
            if(isMoved == 0) //씬 변경되고 나서 움직이지 않았을 때
            {
                player.transform.position = new Vector3(-6.8f, 1.6f, 0);
            }
        }

        if (GameManager.gameManager.first_Lock[0] && GameManager.gameManager.first_Lock[1] && GameManager.gameManager.first_Lock[2] && GameManager.gameManager.second_Lock[0] && GameManager.gameManager.second_Lock[1] && GameManager.gameManager.second_Lock[2])
        {
            scene.transferMap = "Rocket_Unlocked";
        }

        if (GameManager.gameManager.O2 > 0)
        {
            if(!isCharge[0] && !isCharge[1] && !isCharge[2]) //산소충전이 안되고 있으면 산소 감소
            {
                GameManager.gameManager.O2 -= 1.5f * Time.deltaTime;
            }
        }

        if(GameManager.gameManager.temp > 38) //온도 최대치 38
        {
            GameManager.gameManager.temp = 38;
        }

        GameManager.gameManager.temp += 0.1f * Time.deltaTime;
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
