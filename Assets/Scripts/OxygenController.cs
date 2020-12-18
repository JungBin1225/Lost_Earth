using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OxygenController : MonoBehaviour
{
    public bool isCharge = false;
    public FirstStageManager firstStage;
    public SecondStageManager secondStage;

    public int num;

    void Start()
    {
        firstStage = GameObject.Find("StageManager").GetComponent<FirstStageManager>();
        secondStage = GameObject.Find("StageManager").GetComponent<SecondStageManager>();
    }


    void Update()
    {
        if(SceneManager.GetActiveScene().name.Equals("FirstStage"))
        {
            if (isCharge)
            {
                firstStage.isCharge[num] = true; //스테이지 컨트롤러에 충전 중이라고 저장
                GameManager.gameManager.O2 += 2f * Time.deltaTime; //1초에 1%씩 충전
            }
            else
            {
                firstStage.isCharge[num] = false; // 충전이 끝났다고 전달
            }
        }
        else if(SceneManager.GetActiveScene().name.Equals("SecondStage"))
        {
            if (isCharge)
            {
                secondStage.isCharge[num] = true; //스테이지 컨트롤러에 충전 중이라고 저장
                GameManager.gameManager.O2 += 2f * Time.deltaTime; //1초에 1%씩 충전
            }
            else
            {
                secondStage.isCharge[num] = false; // 충전이 끝났다고 전달
            }
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
