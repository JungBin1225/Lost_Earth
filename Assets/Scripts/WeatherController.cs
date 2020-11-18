using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeatherController : MonoBehaviour
{
    public GameObject player;
    public GameObject snow;
    public GameObject wind;
    public PlayerController playerController;

    public ParticleSystem snowParticle;
    public ParticleSystem windParticle;

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
        wind = GameObject.Find("Wind");

        snowParticle = snow.GetComponent<ParticleSystem>();
        windParticle = wind.GetComponent<ParticleSystem>();

        playerController = player.GetComponent<PlayerController>();

        spawn = Random.Range(spawnMin, spawnMax);

        time = 0;

        ParticleSystem.MainModule main = windParticle.main;
        main.startSpeed = 20;
        main.startLifetime = 1.5f;
    }

    void Update()
    {
        time += Time.deltaTime;

        if (time >= spawn)
        {
            time = 0;

            if (isSnow)
            {
                snowParticle.Stop();
                windParticle.Stop();
                isSnow = false;
            }
            else
            {
                snowParticle.Play();
                windParticle.Play();
                isSnow = true;
            }

            spawn = Random.Range(spawnMin, spawnMax);
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
