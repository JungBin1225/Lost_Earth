using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private Transform transform;
    private Rigidbody2D rigidbody2d;

    public bool isEvent;

    private Animator ani;
    private int aniId;
    private int initId;

    public float speed;

    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        transform = GetComponent<Transform>();
        ani = GetComponent<Animator>();

        speed = 0.1f;
        isEvent = false;
    }

    void Update()
    {
        Vector2 position = rigidbody2d.position;

        if (!isEvent)
        {
            if (Input.GetKey(KeyCode.DownArrow))
            {
                initId = Animator.StringToHash("back");
                ani.SetBool(initId, false);
                aniId = Animator.StringToHash("front");
                ani.SetBool(aniId, true);
                position.y -= speed;
            }
            else if (Input.GetKey(KeyCode.UpArrow))
            {
                initId = Animator.StringToHash("front");
                ani.SetBool(initId, false);
                aniId = Animator.StringToHash("back");
                ani.SetBool(aniId, true);
                position.y += speed;
            }
            else
            {
                initId = Animator.StringToHash("front");
                ani.SetBool(initId, false);
                initId = Animator.StringToHash("back");
                ani.SetBool(initId, false);
            }

            if (Input.GetKey(KeyCode.LeftArrow))
            {
                initId = Animator.StringToHash("left");
                ani.SetBool(initId, false);
                aniId = Animator.StringToHash("right");
                ani.SetBool(aniId, true);
                position.x -= speed;
            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                initId = Animator.StringToHash("right");
                ani.SetBool(initId, false);
                aniId = Animator.StringToHash("left");
                ani.SetBool(aniId, true);
                position.x += speed;
            }
            else
            {
                initId = Animator.StringToHash("left");
                ani.SetBool(initId, false);
                initId = Animator.StringToHash("right");
                ani.SetBool(initId, false);
            }

            rigidbody2d.MovePosition(position);
        }
        else
        {
            initId = Animator.StringToHash("front");
            ani.SetBool(initId, false);
            initId = Animator.StringToHash("back");
            ani.SetBool(initId, false);
            initId = Animator.StringToHash("left");
            ani.SetBool(initId, false);
            initId = Animator.StringToHash("right");
            ani.SetBool(initId, false);
        }
    }

    public void GameOver()
    {
        GameManager.gameManager.Hp = 100;
        GameManager.gameManager.O2 = 100;
        GameManager.gameManager.temp = 30;

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
