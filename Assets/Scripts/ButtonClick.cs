using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonClick : MonoBehaviour
{
    public PlayerController player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    public void ResumeButtonClick()
    {
        if (GameManager.gameManager.stop)
        {
            player.isEvent = false;
            GameManager.gameManager.stop = false;
        }
    }

    public void ExitButtonClick()
    {
        if (GameManager.gameManager.stop)
        {
            Application.Quit();
        }
    }
}
