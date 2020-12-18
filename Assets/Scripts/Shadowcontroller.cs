using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shadowcontroller : MonoBehaviour
{
    public float shadowTime;


    void Start()
    {
        shadowTime = 2.5f;
    }


    void Update()
    {
        shadowTime -= Time.deltaTime;
        transform.localScale -= new Vector3(2 * Time.deltaTime, 2 * Time.deltaTime, 1);

        if(shadowTime <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
