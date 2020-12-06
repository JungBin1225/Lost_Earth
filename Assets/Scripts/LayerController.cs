using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayerController : MonoBehaviour
{
    public GameObject player;
    public GameObject asd;
    public SpriteRenderer playerLayer;
    public SpriteRenderer objectLayer;

    private int layer;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerLayer = player.GetComponent<SpriteRenderer>();
        objectLayer = GetComponent<SpriteRenderer>();

        layer = objectLayer.sortingOrder;
    }

    void Update()
    {
        if (player.transform.position.y - (playerLayer.sprite.rect.height / 46) > transform.position.y - (objectLayer.sprite.rect.height / 45)) //플레이어가 오브젝트보다 위에 있을 때
        {
            if(objectLayer.sortingOrder == layer)
            {
                objectLayer.sortingOrder += playerLayer.sortingOrder;
            }
        }
        else
        {
            if(objectLayer.sortingOrder != layer)
            {
                objectLayer.sortingOrder = layer;
            }
        }
    }
}
