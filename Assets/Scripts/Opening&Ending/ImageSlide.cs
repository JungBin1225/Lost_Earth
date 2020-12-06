using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ImageSlide : MonoBehaviour
{
    public List<Sprite> imageList;
    public TextAsset textFile;
    private AudioSource bgm;

    public Image imageCanvas;
    public Text script;

    private string writeText = "";

    public bool isPlay = true;
    private bool end = false;

    void Start()
    {
        imageCanvas = GameObject.Find("illustration").GetComponent<Image>();
        script = GameObject.Find("Script").GetComponent<Text>();
        bgm = GameObject.Find("BGM").GetComponent<AudioSource>();

        StartCoroutine(textDeliver(textFile, imageList));
    }


    IEnumerator textDeliver(TextAsset text, List<Sprite> image) //NPC 대화창과 비슷
    {
        int index = 0;
        string dialoge = text.text;
        string[] message = dialoge.Split('\n');

        for (int i = 0; i < message.Length; i++)
        {
            imageCanvas.sprite = imageList[index];
            writeText = "";
            for (int a = 2; a < message[i].Length; a++)
            {
                if(message[i][a].Equals('+')) //+가 있으면 이미지를 다음으로 넘김
                {
                    index++;
                }
                else
                {
                    writeText += message[i][a];
                    if (message[i][0].Equals('손')) //손자는 노란색
                    {
                        script.text = "<color=#fbff00>"+ writeText + "</color>";
                    }
                    else
                    {
                        script.text = "<color=#ffffff>"+ writeText + "</color>"; //할머니는 흰색
                    }
                    //script.text = writeText;
                }
                yield return new WaitForSeconds(0.1f);
            }

            if (i == message.Length - 2)
            {
                end = true;
            }
            yield return new WaitForSeconds(0.6f);
        }

        script.text = "";
        isPlay = false;
        
    }

    void Update()
    {
        if (!end && bgm.volume < 1.0f)
        {
            bgm.volume += Time.deltaTime * 0.5f;
        }
        else if (end)
        {
            bgm.volume -= Time.deltaTime * 0.5f;
        }
        
        if(!isPlay)
        {
            if(SceneManager.GetActiveScene().name.Equals("Opening"))
            {
                SceneManager.LoadScene("Start");
            }
        }
    }
}
