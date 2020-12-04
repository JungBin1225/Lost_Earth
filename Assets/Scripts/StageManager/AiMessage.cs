using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AiMessage : MonoBehaviour
{
    public Text message;
    public Image textWindow;
    public FirstStageManager stageManager;
    public AudioSource robotSound;

    public bool O2_50per = false;
    public bool Hp_50per = false;

    public bool lock_first = false;
    public bool lock_second = false;
    public bool lock_third = false;

    public bool charge = false;

    public bool appear = false;

    public float appearTime = 0;
    public float posX = 375;
    void Start()
    {
        stageManager = GameObject.Find("StageManager").GetComponent<FirstStageManager>();
        textWindow = GetComponentInChildren<Image>();
        message = GetComponentInChildren<Text>();
        robotSound = GetComponent<AudioSource>();

        textWindow.rectTransform.anchoredPosition = new Vector2(375, 150);
    }

    private void MessageAppear(string appearmessage, ref bool state)
    {
        message.text = appearmessage;
        if (!appear)
        {
            robotSound.Play();
            if (posX >= -375) //왼쪽으로 천천히 등장
            {
                posX -= 300 * Time.deltaTime;
                textWindow.rectTransform.anchoredPosition = new Vector2(posX, 150);
            }
            else if (appearTime <= 5) //5초동안 머무름
            {
                appearTime += Time.deltaTime;
            }
            else
            {
                appear = true;
            }
        }
        else
        {
            if (posX <= 375) //오른쪽으로 천천히 퇴장
            {
                posX += 300 * Time.deltaTime;
                textWindow.rectTransform.anchoredPosition = new Vector2(posX, 150);
            }
            else
            {
                appear = false;
                appearTime = 0;
                state = true; //스테이지 당 1번씩만 등장하게
            }

        }
    }

    void Update()
    {
        if (!O2_50per)
        {
            if (GameManager.gameManager.O2 <= 50)
            {
                MessageAppear("산소가 50% 이하입니다. 주변의 산소발생기를 찾으십시오.", ref O2_50per);
                return;
            }
        }

        if (!Hp_50per)
        {
            if (GameManager.gameManager.Hp <= 50)
            {
                MessageAppear("체력이 50% 이하입니다. 음식을 섭취하여 체력을 보존하십시오.", ref Hp_50per);
                return;
            }
        }

        if (!lock_first)
        {
            if(GameManager.gameManager.first_Lock[0] == true)
            {
                MessageAppear("잠금장치 3개 중 " + GameManager.gameManager.first_Lock_num.ToString() + "개를 해제하였습니다.", ref lock_first);
                return;
            }
        }

        if (!lock_second)
        {
            if (GameManager.gameManager.first_Lock[1] == true)
            {
                MessageAppear("잠금장치 3개 중 " + GameManager.gameManager.first_Lock_num.ToString() + "개를 해제하였습니다.", ref lock_second);
                return;
            }
        }

        if (!lock_third)
        {
            if (GameManager.gameManager.first_Lock[2] == true)
            {
                MessageAppear("잠금장치 3개 중 " + GameManager.gameManager.first_Lock_num.ToString() + "개를 해제하였습니다.", ref lock_third);
                return;
            }
        }

        if (stageManager.isCharge.Contains(true)) //산소 충전은 충전중에는 계속 뜨고 충전 범위에서 나오면 바로 들어가게 해서 코드를 다르게 짬
        {
            message.text = "산소를 충전중입니다.";
            if (posX >= -375)
            {
                posX -= 300 * Time.deltaTime;
                textWindow.rectTransform.anchoredPosition = new Vector2(posX, 150);
            }
        }
        else
        {
            if (posX <= 375)
            {
                posX += 300 * Time.deltaTime;
                textWindow.rectTransform.anchoredPosition = new Vector2(posX, 150);
            }
            else
            {
                charge = true;
            }
        }
    }
}
