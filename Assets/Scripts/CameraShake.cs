using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public float shakeAmount = 5;
    public float shakeTime = 5;
    Vector3 initPosition;
    void Start()
    {
        initPosition = Camera.main.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(shakeTime > 0)
        {
            transform.position = Random.insideUnitSphere * shakeAmount + initPosition;
            shakeTime -= Time.deltaTime;
        }
        else
        {
            shakeTime = 0;
            transform.position = initPosition;
        }
    }
}
