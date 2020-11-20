using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour
{

    void Start()
    {
        
    }


    void Update()
    {
        if(GameManager.gameManager.O2 > 0)
        {
            GameManager.gameManager.O2 -= 1f * Time.deltaTime;
        }
    }
}
