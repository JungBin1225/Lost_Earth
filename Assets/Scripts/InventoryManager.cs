using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    void Update()
    {
        for (int i = 0; i < 5; i++)
        {
            transform.GetChild(i).GetComponent<Image>().sprite = null;
            transform.GetChild(i).GetComponent<Image>().color = Color.clear;
        }

        foreach (GameObject item in GameManager.gameManager.inventory)
        {
            transform.GetChild(GameManager.gameManager.inventory.IndexOf(item)).GetComponent<Image>().sprite = item.GetComponent<SpriteRenderer>().sprite;
            transform.GetChild(GameManager.gameManager.inventory.IndexOf(item)).GetComponent<Image>().color = Color.white;
        }
    }
}
