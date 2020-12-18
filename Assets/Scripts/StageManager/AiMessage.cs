using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AiMessage : MonoBehaviour
{
    public Text message;
    public Image textWindow;
    public FirstStageManager stageManager;
    public SecondStageManager secondStage;
    public AudioSource AiSound;

    public bool O2_50per = false;
    public bool Hp_50per = false;

    public bool lock_first = false;
    public bool lock_second = false;
    public bool lock_third = false;
    public bool Slock_first = false;
    public bool Slock_second = false;
    public bool Slock_third = false;
    public bool main_lock = true;

    public bool charge = false;

    public bool appear = false;

    public bool sound = false;

    public float appearTime = 0;
    public float posX = 375;
    void Start()
    {
        stageManager = GameObject.Find("StageManager").GetComponent<FirstStageManager>();
        secondStage = GameObject.Find("StageManager").GetComponent<SecondStageManager>();
        textWindow = GetComponentInChildren<Image>();
        message = GetComponentInChildren<Text>();
        AiSound = GetComponent<AudioSource>();

        textWindow.rectTransform.anchoredPosition = new Vector2(375, 150);
    }

    private void MessageAppear(string appearmessage, ref bool state)
    {
        if (!sound)
        {
            AiSound.Play();
            sound = true;
        }

        message.text = appearmessage;
        if (!appear)
        {
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
                sound = false;
            }

        }
    }

    private void MessageAppear(string appearmessage, ref bool state, ref bool state2)
    {
        if(!sound)
        {
            AiSound.Play();
            sound = true;
        }

        message.text = appearmessage;
        if (!appear)
        {
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
                state2 = true;
                sound = false;
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
            if(GameManager.gameManager.first_Lock[0] == true && GameManager.gameManager.first_message[0] == false)
            {
                if (GameManager.gameManager.first_Lock[0] && GameManager.gameManager.first_Lock[1] && GameManager.gameManager.first_Lock[2])
                {
                    MessageAppear("잠금장치 3개를 모두 해제하였습니다", ref lock_first, ref GameManager.gameManager.first_message[0]);
                }
                else
                {
                    MessageAppear("잠금장치 3개 중 " + GameManager.gameManager.first_Lock_num.ToString() + "개를 해제하였습니다.", ref lock_first, ref GameManager.gameManager.first_message[0]);
                }
                return;
            }
        }

        if (!lock_second)
        {
            if (GameManager.gameManager.first_Lock[1] == true && GameManager.gameManager.first_message[1] == false)
            {
                if (GameManager.gameManager.first_Lock[0] && GameManager.gameManager.first_Lock[1] && GameManager.gameManager.first_Lock[2])
                {
                    MessageAppear("잠금장치 3개를 모두 해제하였습니다", ref lock_second, ref GameManager.gameManager.first_message[1]);
                }
                else
                {
                    MessageAppear("잠금장치 3개 중 " + GameManager.gameManager.first_Lock_num.ToString() + "개를 해제하였습니다.", ref lock_second, ref GameManager.gameManager.first_message[1]);
                }
                return;
            }
        }

        if (!lock_third)
        {
            if (GameManager.gameManager.first_Lock[2] == true && GameManager.gameManager.first_message[2] == false)
            {
                if (GameManager.gameManager.first_Lock[0] && GameManager.gameManager.first_Lock[1] && GameManager.gameManager.first_Lock[2])
                {
                    MessageAppear("잠금장치 3개를 모두 해제하였습니다", ref lock_third, ref GameManager.gameManager.first_message[2]);
                }
                else
                {
                    MessageAppear("잠금장치 3개 중 " + GameManager.gameManager.first_Lock_num.ToString() + "개를 해제하였습니다.", ref lock_third, ref GameManager.gameManager.first_message[2]);
                }
                return;
            }
        }

        if (!Slock_first)
        {
            if (GameManager.gameManager.second_Lock[0] == true && GameManager.gameManager.second_message[0] == false)
            {
                if (GameManager.gameManager.second_Lock[0] && GameManager.gameManager.second_Lock[1] && GameManager.gameManager.second_Lock[2])
                {
                    MessageAppear("잠금장치 3개를 모두 해제하였습니다", ref Slock_first, ref GameManager.gameManager.second_message[0]);
                }
                else
                {
                    MessageAppear("잠금장치 3개 중 " + GameManager.gameManager.second_Lock_num.ToString() + "개를 해제하였습니다.", ref Slock_first, ref GameManager.gameManager.second_message[0]);
                }
                return;
            }
        }

        if (!Slock_second)
        {
            if (GameManager.gameManager.second_Lock[1] == true && GameManager.gameManager.second_message[1] == false)
            {
                if (GameManager.gameManager.second_Lock[0] && GameManager.gameManager.second_Lock[1] && GameManager.gameManager.second_Lock[2])
                {
                    MessageAppear("잠금장치 3개를 모두 해제하였습니다", ref Slock_second, ref GameManager.gameManager.second_message[1]);
                }
                else
                {
                    MessageAppear("잠금장치 3개 중 " + GameManager.gameManager.second_Lock_num.ToString() + "개를 해제하였습니다.", ref Slock_second, ref GameManager.gameManager.second_message[1]);
                }
                return;
            }
        }

        if (!Slock_third)
        {
            if (GameManager.gameManager.second_Lock[2] == true && GameManager.gameManager.second_message[2] == false)
            {
                if (GameManager.gameManager.second_Lock[0] && GameManager.gameManager.second_Lock[1] && GameManager.gameManager.second_Lock[2])
                {
                    MessageAppear("잠금장치 3개를 모두 해제하였습니다", ref Slock_third, ref GameManager.gameManager.second_message[2]);
                }
                else
                {
                    MessageAppear("잠금장치 3개 중 " + GameManager.gameManager.second_Lock_num.ToString() + "개를 해제하였습니다.", ref Slock_third, ref GameManager.gameManager.second_message[2]);
                }
                return;
            }
        }

        if (!main_lock)
        {
            MessageAppear("연결된 모든 잠금 장치를 해제하면 이 잠금 장치가 해제됩니다.", ref main_lock);
            return;
        }


        if(GameManager.gameManager.presentScene.Equals("FirstStage"))
        {
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
        else if(SceneManager.GetActiveScene().name.Equals("SecondStage"))
        {
            if(secondStage.isCharge.Contains(true))
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
}
