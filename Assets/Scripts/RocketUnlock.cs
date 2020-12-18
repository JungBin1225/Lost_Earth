using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketUnlock : MonoBehaviour
{
    public SpriteRenderer objectImage;
    public Sprite unLockImage;
    void Start()
    {
        objectImage = GetComponent<SpriteRenderer>();
    }


    void Update()
    {
        if (GameManager.gameManager.first_Lock[0] && GameManager.gameManager.first_Lock[1] && GameManager.gameManager.first_Lock[2])
        {
            if (objectImage.sprite != unLockImage)
            {
                objectImage.sprite = unLockImage;
            }
        }
    }
}
