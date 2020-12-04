using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public Animator transition;
    public string sceneName;

    public float transitionTime = 1f;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            LoadNextLevel();
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
        GameManager.gameManager.previousScene = SceneManager.GetActiveScene().name;
        GameManager.gameManager.presentScene = sceneName;
        SceneManager.LoadScene(sceneName);
    }
}
