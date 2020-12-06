using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShelterIn : MonoBehaviour
{
    
    void Start()
    {
        
    }

    
    void Update() 
    {
        GameManager.gameManager.O2 = 100;    //산소와 온도 초기화
        GameManager.gameManager.temp = 30f;
    }
}
