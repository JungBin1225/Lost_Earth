using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextController : MonoBehaviour
{
    public NPCController npc;
    public PlayerController player;

    public Text NPCTalk;
    public Text NPCname;

    public string talkText = "";
    public string writeText = "";

    IEnumerator NPCTalking(string name, string talk)
    {
        NPCname.text = name;

        for (int a = 0; a < talk.Length; a++)
        {
            writeText += talk[a];
            NPCTalk.text = writeText;
            yield return new WaitForSeconds(0.1f);
        }
    }

    void Start()
    {
        player = GameObject.Find("Player").GetComponent<PlayerController>();
        npc = GameObject.FindGameObjectWithTag("NPC").GetComponent<NPCController>();
        NPCTalk = GameObject.Find("Dialogue").GetComponent<Text>();
        NPCname = GameObject.Find("Name").GetComponent<Text>();
        NPCTalk.text = "";
        NPCname.text = "";
        talkText = "";
    }

    void Update()
    {
        if (talkText != "")
        {
            if(writeText == "")
            {
                StartCoroutine(NPCTalking(NPCname.text, talkText));
            }
            else if(talkText != NPCTalk.text)
            {
                return;
            }
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            player.isEvent = false;
            NPCTalk.text = "";
            NPCname.text = "";
            writeText = "";
            talkText = "";
        }
    }
}
