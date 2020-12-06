using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOvercontroller : MonoBehaviour
{
    public float time = 0;
    void Start()
    {
        GameManager.gameManager.first_Lock = new bool[] { false, false, false };
    }


    void Update()
    {
        time += Time.deltaTime;

        if(time >= 1)
        {
            if (Input.GetMouseButtonDown(0))
            {
                SceneManager.LoadScene(GameManager.gameManager.presentScene);
            }
        }
    }
}
