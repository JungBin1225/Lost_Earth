using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TextController : MonoBehaviour
{
    public PlayerController player;

    public Image textBox;
    public Text NPCTalk;
    public Text NPCname;

    public string talkText = "";
    public string writeText = "";
    public TextAsset textFile;

    public int i = 100000;
    public bool isMessage = false;

    public bool isCutScene = false;

    IEnumerator textDeliver(TextAsset text, string name) //텍스트 표시
    {
        string dialoge = text.text;
        int a;
        string[] message = dialoge.Split('\n');

        for(i = 0; i < message.Length; i++)
        {
            writeText = "";
            for (a = 2; a < message[i].Length; a++)
            {
                if (message[i][0].Equals('주')) //주인공의 대사이므로 이름을 주인공으로 출력
                {
                    NPCname.text = "주인공";
                }
                else
                {
                    NPCname.text = name; //NPC의 대사이므로 NPC 이름을 출력
                }
                writeText += message[i][a];
                NPCTalk.text = writeText;
                yield return new WaitForSeconds(0.1f); //한 글자당 출력되는 간격을 0.1초로 설정해 타이핑하는 효과를 냄
            }

            if(isCutScene)
            {
                yield return new WaitForSeconds(0.3f);
            }
            else
            {
                yield return new WaitUntil(new System.Func<bool>(nextmessage)); //스페이스 바를 누르면 다음 대사로 넘어감
            }
        }

        isCutScene = false;
        isMessage = false;
        player.isEvent = false;
        i = 100000;
    }

    bool nextmessage()
    {
        return Input.GetKeyUp(KeyCode.Space);
    }

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        NPCTalk = GameObject.Find("Dialogue").GetComponent<Text>();
        NPCname = GameObject.Find("Name").GetComponent<Text>();
        textBox = GameObject.Find("TextBox").GetComponent<Image>();
        NPCTalk.text = "";
        NPCname.text = "";
        talkText = "";
        i = 100000; //한 줄의 글자 수가 100000개는 넘지 않으니 100000이면 텍스트가 출력중이 아님
    }

    void Update()
    {
        if (isMessage)
        {
            if (i == 100000) //텍스트가 출력중이지 않으면
            {
                textBox.gameObject.SetActive(true);
                player.isEvent = true;
                StartCoroutine(textDeliver(textFile, NPCname.text));
            }
            return;
        }
        else
        {
            textBox.gameObject.SetActive(false);
            NPCname.text = "";
            NPCTalk.text = "";
        }
    }
}
