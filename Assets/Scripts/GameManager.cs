using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManager;
    public List<GameObject> inventory;
    public string previousScene = null;
    public string presentScene = null;

    public GameObject hp_Gauge;
    public GameObject O2_Gauge;
    public GameObject Temp_Gauge;
    public GameObject O2_state;
    public GameObject Temp_state;

    public float Hp = 100;
    public float O2 = 100;
    public float temp = 36.5f;

    void Awake()
    {
        if (gameManager == null)
            gameManager = this;

        else if (gameManager != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);

    }

    void Start()
    {
        
    }

    void Update()
    {
        hp_Gauge = GameObject.Find("hp_gauge");
        O2_Gauge = GameObject.Find("O2_gauge");
        Temp_Gauge = GameObject.Find("Temp_gauge");
        O2_state = GameObject.Find("O2_state");
        Temp_state = GameObject.Find("Temp_state");

        if(O2 <= 0)
        {
            if(O2 != 0)
            {
                O2 = 0;
            }
            Hp -= 0.5f * Time.deltaTime;
        }

        hp_Gauge.GetComponent<Image>().fillAmount = Hp / 100;
        O2_Gauge.GetComponent<Image>().fillAmount = O2 / 100;
        Temp_Gauge.GetComponent<Image>().fillAmount = (temp - 10) / 55;
        O2_state.GetComponent<Text>().text = O2.ToString("F0") + "%";
        Temp_state.GetComponent<Text>().text = temp.ToString("F1") + "ºC";
    }
}
