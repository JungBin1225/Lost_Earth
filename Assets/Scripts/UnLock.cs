using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnLock : MonoBehaviour
{
    public GameObject player;
    public SpriteRenderer objectImage;
    public Sprite unLockImage;

    public int number;
    private bool isTouch = false;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        objectImage = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isTouch)
        {
            if(Input.GetKeyUp(KeyCode.Space))
            {
                if(player.transform.position.y < transform.position.y && player.transform.position.x - transform.position.x < 0.5 && player.transform.position.x - transform.position.x > -0.5)
                {
                    if(!GameManager.gameManager.first_Lock[number])
                    {
                        GameManager.gameManager.first_Lock_num++;
                    }
                    GameManager.gameManager.first_Lock[number] = true;
                }
            }
        }

        if(GameManager.gameManager.first_Lock[number])
        {
            if(objectImage.sprite != unLockImage)
            {
                objectImage.sprite = unLockImage;
            }
            
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player")
        {
            isTouch = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player")
        {
            isTouch = false;
        }
    }
}
