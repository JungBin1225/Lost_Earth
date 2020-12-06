using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageSlideEnding : MonoBehaviour
{
    public List<Sprite> imageList;
    private AudioSource bgm;

    public Image imageCanvas;
    public float time = 0;

    public bool isPlay = true;
    private bool end = false;

    void Start()
    {
        imageCanvas = GameObject.Find("illustration").GetComponent<Image>();
        bgm = GameObject.Find("BGM").GetComponent<AudioSource>();
    }

    void Update()
    {
        time += Time.deltaTime;

        if (!end && bgm.volume < 1.0f)
        {
            bgm.volume += Time.deltaTime * 0.5f;
        }

        if (isPlay)
        {
            if(time < 1.5f)
            {
                imageCanvas.sprite = imageList[0];
            }
            else if(time >= 1.5f  && time < 3.0f)
            {
                imageCanvas.sprite = imageList[1];
            }
            else
            {
                imageCanvas.sprite = imageList[2];
                isPlay = false;
            }
        }
    }
}
