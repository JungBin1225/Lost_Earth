using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteoController : MonoBehaviour
{
    public Vector2 pos;
    public SpriteRenderer image;
    public Sprite shadow;
    public Sprite meteo;

    public float shadowTime;
    public float meteoTime;

    public bool warning = true;
    public bool hitBox = false;
    void Start()
    {
        image = GetComponent<SpriteRenderer>();
        transform.position = pos;
        shadowTime = 5;
        meteoTime = 5;
    }

    void Update()
    {
        if(warning)
        {
            image.sprite = shadow;
            shadowTime -= Time.deltaTime;
            transform.localScale -= new Vector3(Time.deltaTime, Time.deltaTime, 1);

            if(shadowTime < 0)
            {
                warning = false;
                transform.position = new Vector2(pos.x + 5, pos.y + 5);
                transform.localScale = new Vector3(3, 3, 1);
            }
        }
        else
        {
            image.sprite = meteo;
            meteoTime -= Time.deltaTime;
            transform.position = new Vector2(transform.position.x - Time.deltaTime, transform.position.y - Time.deltaTime);

            if(meteoTime < 0)
            {
                if(hitBox == true)
                {
                    GameManager.gameManager.Hp -= 20;  
                }
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
