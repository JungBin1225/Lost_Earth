using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RocketAI : MonoBehaviour
{
    public Text message;
    public Image textWindow;

    public bool appear = false;

    public float appearTime = 0;
    public float posX = 375;

    public bool ismessage = false;
    void Start()
    {
        textWindow = GetComponentInChildren<Image>();
        message = GetComponentInChildren<Text>();

        textWindow.rectTransform.anchoredPosition = new Vector2(375, 150);
    }

    private void MessageAppear(string appearmessage, ref bool state)
    {
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
                state = false; //스테이지 당 1번씩만 등장하게
            }

        }
    }

    void Update()
    {
        if(ismessage)
        {
            MessageAppear("연결된 모든 잠금 장치를 해제하면 이 잠금 장치가 해제됩니다.", ref ismessage);
        }
    }
}
