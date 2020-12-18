using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteoGenerator : MonoBehaviour
{
    public GameObject meteoPrefeb;
    public GameObject shadowPrefeb;

    public GameObject player;

    public float max_posX;
    public float min_posX;
    public float max_posY;
    public float min_posY;

    public int meteo_num;

    public List<Vector3> meteo_pos;

    public bool ismeteo = true;

    public float time = 0;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    
    void Update()
    {
        time += Time.deltaTime;

        if(time > 30)
        {
            ismeteo = false;
            time = 0;
        }


        if(!ismeteo)
        {
            ismeteo = true;
            float posX;
            float posY;

            for (int i = 0; i < meteo_num; i++)
            {
                posX = Random.Range(min_posX, max_posX);
                posY = Random.Range(min_posY, max_posY);

                meteo_pos.Add(new Vector3(player.transform.position.x + posX, player.transform.position.y + posY, 0));
            }

            StartCoroutine(generate());
        }
    }

    public IEnumerator generate()
    {
        foreach(Vector3 position in meteo_pos)
        {
            GameObject meteo = Instantiate(meteoPrefeb) as GameObject;
            GameObject shadow = Instantiate(shadowPrefeb) as GameObject;

            meteo.GetComponent<MeteoController>().pos = position;
            shadow.transform.position = position;

            yield return new WaitForSeconds(0.2f);
        }

        meteo_pos.Clear();
    }
}
