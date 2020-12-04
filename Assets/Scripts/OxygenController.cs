using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OxygenController : MonoBehaviour
{
    public bool isCharge = false;
    public FirstStageManager firstStage;

    public int num;

    void Start()
    {
        firstStage = GameObject.Find("StageManager").GetComponent<FirstStageManager>();
    }


    void Update()
    {
        if(isCharge)
        {
            firstStage.isCharge[num] = true; //스테이지 컨트롤러에 충전 중이라고 저장
            GameManager.gameManager.O2 += 1f * Time.deltaTime; //1초에 1%씩 충전
        }
        else
        {
            firstStage.isCharge[num] = false; // 충전이 끝났다고 전달
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            isCharge = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            isCharge = false;
        }
    }
}
