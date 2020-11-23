using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public float shakeAmount = 5;
    public float shakeTime = 5;

    GameObject player;
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if(shakeTime > 0)
        {
            transform.position = Random.insideUnitSphere * shakeAmount + player.transform.position;
            transform.position = new Vector3(transform.position.x, transform.position.y, -10);
            shakeTime -= Time.deltaTime;
        }
        else if(shakeTime < 0)
        {
            shakeTime = 0;
            transform.position = player.transform.position;
            transform.position = new Vector3(transform.position.x, transform.position.y, -10);
        }
    }
}
