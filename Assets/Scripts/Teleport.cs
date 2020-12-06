using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Teleport : MonoBehaviour
{
    public GameObject player;
    public Animator transition;
    
    public string transferMap; //이동할 맵
    public float transitionTime = 1f;
    
    private bool isTouch = false;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    
    void Update()
    {
        if(isTouch)
        {
            if(Input.GetKeyUp(KeyCode.Space))
            {
                GameManager.gameManager.previousScene = SceneManager.GetActiveScene().name;
                GameManager.gameManager.presentScene = transferMap;
                LoadNextLevel();
            }
        }
    }
    
    public void LoadNextLevel()
    {
        StartCoroutine(LoadLevel());
    }
    
    IEnumerator LoadLevel()
    {
        //play animation
        transition.SetTrigger("Start");
        
        //wait
        yield return new WaitForSeconds(transitionTime); 
        
        //load scene
        SceneManager.LoadScene(transferMap);
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
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
