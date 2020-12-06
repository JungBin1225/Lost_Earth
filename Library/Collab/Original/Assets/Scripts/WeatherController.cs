using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeatherController : MonoBehaviour
{
    public GameObject player;
    public GameObject snow;
    public UB.Simple2dWeatherEffects.Standard.D2FogsPE wind;
    public PlayerController playerController;

    public ParticleSystem snowParticle;

    public bool isSnow;

    public float spawnMax = 20f;
    public float spawnMin = 10f;

    private float spawn;
    private float time;

    void Start()
    {
        isSnow = true;

        player = GameObject.Find("Player");
        snow = GameObject.Find("Snow");
        wind = Camera.main.GetComponent<UB.Simple2dWeatherEffects.Standard.D2FogsPE>();

        snowParticle = snow.GetComponent<ParticleSystem>();

        playerController = player.GetComponent<PlayerController>();

        spawn = Random.Range(spawnMin, spawnMax);

        time = 0;
    }

    void Update()
    {
        time += Time.deltaTime;

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
                    isSnow = false;
                    time = 0;
                    spawn = Random.Range(spawnMin, spawnMax);
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
                    isSnow = true;
                    time = 0;
                    spawn = Random.Range(spawnMin, spawnMax);
                }
            }
        }

        if (isSnow)
        {
            GameManager.gameManager.temp -= 0.7f * Time.deltaTime;
        }
        else
        {
            GameManager.gameManager.temp += 0.3f * Time.deltaTime;
        }
    }
}
