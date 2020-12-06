using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingCredit : MonoBehaviour
{
    public ImageSlide_Ending slider;

    public float posY;
    void Start()
    {
        slider = GameObject.Find("imageSlide").GetComponent<ImageSlide_Ending>();
    }

    void Update()
    {
        if(!slider.isPlay)
        {
            posY += 100 * Time.deltaTime;
        }

        gameObject.transform.localPosition = new Vector3(0, posY, 0);
    }
}
