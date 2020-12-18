using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaController : MonoBehaviour
{
    private bool isTouched = false;

    public bool isDamage = false;

    void Start()
    {
        
    }

    
    void Update()
    {
        if(isTouched)
        {
            if(!isDamage)
            {
                Camera.main.GetComponent<CameraShake>().shakeTime = 0.5f;
                GameManager.gameManager.Hp -= 80;
                isDamage = true;
            }
        }
        else
        {
            isDamage = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            isTouched = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            isTouched = false;
        }
    }
}
