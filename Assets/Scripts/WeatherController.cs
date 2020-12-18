using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeatherController : MonoBehaviour
{
    public GameObject player;
    public GameObject snow;
    public UB.Simple2dWeatherEffects.Standard.D2FogsPE wind;
    public PlayerController playerController;
    public AudioSource windSound;

    public ParticleSystem snowParticle;

    public bool isSnow;

    public float spawnMax = 30f; //랜덤 주기 최댓값
    public float spawnMin = 20f; //랜덤 주기 최솟값

    private float spawn; //모래바람 주기
    private float time;

    void Start()
    {
        isSnow = true;

        player = GameObject.FindGameObjectWithTag("Player");
        snow = GameObject.Find("Snow");
        wind = Camera.main.GetComponent<UB.Simple2dWeatherEffects.Standard.D2FogsPE>();
        windSound = GetComponent<AudioSource>();

        snowParticle = snow.GetComponent<ParticleSystem>();

        playerController = player.GetComponent<PlayerController>();

        spawn = Random.Range(spawnMin, spawnMax);
        // 랜덤으로 주기 결정하기 싫으면 spawn = 숫자; 하면 됨

        time = 0;
    }

    void Update()
    {
        time += Time.deltaTime;

        if(isSnow)
        {
            playerController.speed = 0.07f;// 캐릭터 이동속도 변경(기본 = 0.1f)
        }
        else
        {
            playerController.speed = 0.1f;
        }

        if (time >= spawn)
        {
            if (isSnow)
            {
                if(wind.Density > 0)
                {
                    wind.Density -= 2 * Time.deltaTime;
                }
                else
                {
                    snowParticle.Stop();
                    windSound.Stop();
                    isSnow = false;
                    time = 0;
                    spawn = Random.Range(spawnMin, spawnMax); //랜덤으로 주기 부여
                    // 랜덤으로 주기 결정하기 싫으면 spawn = 숫자; 하면 됨
                }
            }
            else
            {
                if (wind.Density < 1)
                {
                    wind.Density += 2 * Time.deltaTime;
                }
                else
                {
                    snowParticle.Play();
                    windSound.Play();
                    isSnow = true;
                    time = 0;
                    spawn = Random.Range(spawnMin, spawnMax);//랜덤으로 주기 부여
                    // 랜덤으로 주기 결정하기 싫으면 spawn = 숫자; 하면 됨
                }
            }
        }
    }
}
