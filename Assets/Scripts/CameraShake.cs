using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public float shakeAmount = 5;//흔들리는 정도
    public float shakeTime = 5; //흔들리는 시간

    GameObject player;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        if(shakeTime > 0)
        {
            transform.position = Random.insideUnitSphere * shakeAmount + player.transform.position; //현재의 좌표에서 원 안의 랜덤 좌표를 설정
            transform.position = new Vector3(transform.position.x, transform.position.y, -10); //랜덤으로 정한 좌표로 이동
            shakeTime -= Time.deltaTime;
        }
        else if(shakeTime < 0)
        {
            shakeTime = 0;
            transform.position = player.transform.position; //카메라는 플레이어와 같이 움직이기 때문에 시간이 지나면 다시 플레이어의 위치로 돌아옴
            transform.position = new Vector3(transform.position.x, transform.position.y, -10); //z좌표가 플레이어와 같으면 플레이어가 안보이므로 -10으로 설정
        }
    }
}
