using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodBoxImage : MonoBehaviour
{
    public SpriteRenderer objectImage;
    public Sprite unLockImage;
    public NPCController text;

    private bool isTouch = false;
    void Start()
    {
        objectImage = GetComponent<SpriteRenderer>();
        text = GetComponent<NPCController>();
    }


    void Update()
    {
        if (isTouch)
        {
            if(Input.GetKeyUp(KeyCode.Space))
            {
                if (!GameManager.gameManager.foodBox)
                {
                    GameManager.gameManager.foodBox = true;
                }
            }
        }

        if(GameManager.gameManager.foodBox)
        {
            if (objectImage.sprite != unLockImage)
            {
                objectImage.sprite = unLockImage;
            }
            else
            {
                Destroy(text);
                Destroy(this);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            isTouch = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            isTouch = false;
        }
    }
}
