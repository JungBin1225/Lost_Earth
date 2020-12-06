using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoketCamera : MonoBehaviour
{
    public GameObject player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    
    void Update()
    {
        transform.position = new Vector3(0, player.transform.position.y, -10);
    }
}
