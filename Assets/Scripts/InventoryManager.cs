using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    void Update()
    {
        for (int i = 0; i < 5; i++) //이미지가 겹치지 않게 매번 이미지를 초기화해줌
        {
            transform.GetChild(i).GetComponent<Image>().sprite = null;
            transform.GetChild(i).GetComponent<Image>().color = Color.clear;
        }

        foreach (GameObject item in GameManager.gameManager.inventory) //총 5개의 인벤토리 항목을 UI에 배치
        {
            transform.GetChild(GameManager.gameManager.inventory.IndexOf(item)).GetComponent<Image>().sprite = item.GetComponent<SpriteRenderer>().sprite;
            transform.GetChild(GameManager.gameManager.inventory.IndexOf(item)).GetComponent<Image>().color = Color.white;
        }
    }
}
