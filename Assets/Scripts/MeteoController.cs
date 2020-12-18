using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteoController : MonoBehaviour
{
    public Vector3 pos;
    public GameObject player;

    public bool warning = true;
    public bool hitBox = false;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        if(warning)
        {
            transform.position = new Vector3(pos.x + 5, pos.y + 5, 0);
            warning = false;
        }
        else
        {
            transform.position = new Vector3(transform.position.x - (2 * Time.deltaTime), transform.position.y - (1.9f * Time.deltaTime), 0);

            if (pos.x > transform.position.x - 0.1f)
            {
                if (hitBox)
                {
                    GameManager.gameManager.Hp -= 10;
                }
                Camera.main.GetComponent<CameraShake>().shakeTime = 1;
                Destroy(this.gameObject);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            hitBox = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            hitBox = false;
        }
    }
}
