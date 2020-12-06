using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManager;
    public List<GameObject> inventory;
    public List<int> itemNum;
    public string previousScene = null;
    public string presentScene = null;

    public PlayerController player;

    public GameObject hp_Gauge;
    public GameObject O2_Gauge;
    public GameObject Temp_Gauge;
    public GameObject O2_state;
    public GameObject Temp_state;

    public float Hp = 100;
    public float O2 = 100;
    public float temp = 30.0f;

    public bool[] first_Lock = { false, false, false };

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
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
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
            Hp -= 1.0f * Time.deltaTime;
        }

        if(Hp > 100)
        {
            Hp = 100;
        }
        if(O2 > 100)
        {
            O2 = 100;
        }


        if (Input.GetKeyUp(KeyCode.Alpha1))
        {
            if (inventory.Count > 0)
            {
               inventory.RemoveAt(0);
               Hp += 35;
            }
        }
        else if (Input.GetKeyUp(KeyCode.Alpha2))
        {
            if (inventory.Count > 1)
            {
                inventory.RemoveAt(1);
                Hp += 35;
            }
        }
        else if (Input.GetKeyUp(KeyCode.Alpha3))
        {
            if (inventory.Count > 2)
            {
                inventory.RemoveAt(2);
                Hp += 35;
            }
        }
        else if (Input.GetKeyUp(KeyCode.Alpha4))
        {
            if (inventory.Count > 3)
            {
                inventory.RemoveAt(3);
                Hp += 35;
            }
        }
        else if (Input.GetKeyUp(KeyCode.Alpha5))
        {
            if (inventory.Count > 4)
            {
                inventory.RemoveAt(4);
                Hp += 35;
            }
        }

        if(Hp < 0)
        {
            player.GameOver();
        }

        hp_Gauge.GetComponent<Image>().fillAmount = Hp / 100;
        O2_Gauge.GetComponent<Image>().fillAmount = O2 / 100;
        Temp_Gauge.GetComponent<Image>().fillAmount = (temp - 10) / 55;
        O2_state.GetComponent<Text>().text = O2.ToString("F0") + "%";
        Temp_state.GetComponent<Text>().text = temp.ToString("F1") + "ºC";
    }
}
