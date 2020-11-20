using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    GameObject item;

    private bool isTouch = false;

    void Start()
    {
        item = this.gameObject;
        if (GameManager.gameManager.inventory.Contains(this.gameObject))
        {
            item.SetActive(false);
        }
    }

    void Update()
    {
        if(isTouch)
        {
            if(Input.GetKeyUp(KeyCode.Space))
            {
                GameManager.gameManager.inventory.Add(item);
                item.SetActive(false);

                isTouch = false;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
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
