using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRoomDoorController : MonoBehaviour
{
    private Animator animator;
    private bool isTouch = false;
    
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isTouch)
        {
            if(Input.GetKeyUp(KeyCode.Space))
            {
                animator.SetBool("Door open", true);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
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
