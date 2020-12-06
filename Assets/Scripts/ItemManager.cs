using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    GameObject item;
    public GameObject prefeb;

    public int itemID;

    private bool isTouch = false;

    void Start()
    {
        item = this.gameObject;
        if (GameManager.gameManager.itemNum.Contains(itemID)) //인벤토리에 획득한 적 있으면 나타나지 않도록 함
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
                if (prefeb != null)
                {
                    GameManager.gameManager.inventory.Add(prefeb); //씬을 옮기면 missing object가 되어서 프리펩으로 만들어 저장함
                }
                GameManager.gameManager.itemNum.Add(itemID); //씬을 옮겼다 와도 중복으로 못 얻게 하기 위함
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
