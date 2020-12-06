using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoupBox : MonoBehaviour
{
    public GameObject player;
    public SpriteRenderer objectImage;
    public Sprite changedImage;

    private bool isTouch = false;
    private bool isBoxEmpty = false;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        objectImage = GetComponent<SpriteRenderer>();
        isBoxEmpty = GameManager.gameManager.soup;
    }

    // Update is called once per frame
    void Update()
    {
        if(isTouch)
        {
            if(Input.GetKeyUp(KeyCode.Space))
            {
                if(player.transform.position.x - transform.position.x < 1.0 && player.transform.position.x - transform.position.x > -0.5)
                {
                    GameManager.gameManager.soup = true;
                    isBoxEmpty = GameManager.gameManager.soup;
                }
            }
        }

        if(isBoxEmpty)
        {
            if(objectImage.sprite != changedImage)
            {
                objectImage.sprite = changedImage;
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
            isTouch = true;
        }
    }
}
