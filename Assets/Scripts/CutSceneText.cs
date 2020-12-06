using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class CutSceneText : MonoBehaviour
{
    public TextController textController;
    public PlayerController player;

    public string NPCname;
    public TextAsset textFile;

    public PlayableDirector timeLine;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        timeLine = GetComponent<PlayableDirector>();
        textController = GameObject.Find("NPCTalking").GetComponent<TextController>();
    }


    void Update()
    {
        if (timeLine.time >= 10 && timeLine.time <= 10.2)
        {
            player.isEvent = true;
            textController.isCutScene = true;
            textController.isMessage = true; //메세지를 출력함
            textController.NPCname.text = NPCname;
            textController.textFile = textFile;
        }
    }
}
