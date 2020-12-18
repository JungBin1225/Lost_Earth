using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketUnlock2 : MonoBehaviour
{
    public SpriteRenderer objectImage;
    public Sprite unLockImage;
    void Start()
    {
        objectImage = GetComponent<SpriteRenderer>();
    }


    void Update()
    {
        if (GameManager.gameManager.second_Lock[0] && GameManager.gameManager.second_Lock[1] && GameManager.gameManager.second_Lock[2])
        {
            if (objectImage.sprite != unLockImage)
            {
                objectImage.sprite = unLockImage;
            }
        }
    }
}
