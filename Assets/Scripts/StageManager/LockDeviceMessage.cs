using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockDeviceMessage : MonoBehaviour
{
    private bool isTouch = false;

    public AiMessage aiMessage;
    void Start()
    {
        aiMessage = GameObject.Find("AITalking").GetComponent<AiMessage>();
    }

    
    void Update()
    {
        if(isTouch)
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                aiMessage.main_lock = false;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "Player")
        {
            isTouch = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player")
        {
            isTouch = false;
        }
    }
}
