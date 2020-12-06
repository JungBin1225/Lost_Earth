using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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

    public GameObject menu;

    public float Hp = 100;
    public float O2 = 100;
    public float temp = 30.0f;

    public bool[] first_Lock = { false, false, false };
    public bool[] first_message = { false, false, false };
    public int first_Lock_num = 0;
    public bool soup = false;
    public bool stop = false;
    public bool foodBox = false;
    public bool grandMother_light = false;
    public bool first_look = false;

    public int grandMother_num = 0;

    void Awake() //씬이 바뀌어도 파괴되지 않음
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
        if(SceneManager.GetActiveScene().name.Equals("GameOver"))
        {
            return;
        }
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();

        if(SceneManager.GetActiveScene().name.Equals("FirstStage") || SceneManager.GetActiveScene().name.Equals("Rocket_Locked") || SceneManager.GetActiveScene().name.Equals("Rocket_Unlocked") || SceneManager.GetActiveScene().name.Equals("ShelterIn"))
        {
            hp_Gauge = GameObject.Find("hp_gauge");
            O2_Gauge = GameObject.Find("O2_gauge");
            Temp_Gauge = GameObject.Find("Temp_gauge");
            O2_state = GameObject.Find("O2_state");
            Temp_state = GameObject.Find("Temp_state");

            hp_Gauge.GetComponent<Image>().fillAmount = Hp / 100; //UI에 현재 Hp, 산소, 온도를 표시
            O2_Gauge.GetComponent<Image>().fillAmount = O2 / 100;
            Temp_Gauge.GetComponent<Image>().fillAmount = (temp - 10) / 55;
            O2_state.GetComponent<Text>().text = O2.ToString("F0") + "%";
            Temp_state.GetComponent<Text>().text = temp.ToString("F1") + "ºC";
        }

        menu = GameObject.Find("Pause");

        if (O2 <= 0) //산소 최소치 0%
        {
            if(O2 != 0)
            {
                O2 = 0;
            }
            Hp -= 2.0f * Time.deltaTime;
        }

        if(Hp > 100) //체력 최대치 100
        {
            Hp = 100;
        }
        if(O2 > 100) //체력 최소치 0
        {
            O2 = 100;
        }


        if (Input.GetKeyUp(KeyCode.Alpha1) && Hp != 100) //1번 인벤토리 창 -> 키보드 1번 키를 눌러 사용
        {
            if (inventory.Count > 0)
            {
               inventory.RemoveAt(0);
               Hp += 35;
            }
        }
        else if (Input.GetKeyUp(KeyCode.Alpha2) && Hp != 100) //2번 인벤토리 창 -> 키보드 2번 키를 눌러 사용
        {
            if (inventory.Count > 1)
            {
                inventory.RemoveAt(1);
                Hp += 35;
            }
        }
        else if (Input.GetKeyUp(KeyCode.Alpha3) && Hp != 100) //3번 인벤토리 창 -> 키보드 3번 키를 눌러 사용
        {
            if (inventory.Count > 2)
            {
                inventory.RemoveAt(2);
                Hp += 35;
            }
        }
        else if (Input.GetKeyUp(KeyCode.Alpha4) && Hp != 100) //4번 인벤토리 창 -> 키보드 4번 키를 눌러 사용
        {
            if (inventory.Count > 3)
            {
                inventory.RemoveAt(3);
                Hp += 35;
            }
        }
        else if (Input.GetKeyUp(KeyCode.Alpha5) && Hp != 100) //5번 인벤토리 창 -> 키보드 5번 키를 눌러 사용
        {
            if (inventory.Count > 4)
            {
                inventory.RemoveAt(4);
                Hp += 35;
            }
        }

        if(Hp <= 0) //체력이 0이되면 게임오버
        {
            player.GameOver();
        }

        if(Input.GetKeyUp(KeyCode.Escape)) //ESC 누르면 일시정지
        {
            stop = !stop;
        }


        if(stop) //일시정지 하면 게임 종료 메뉴 등장
        {
            menu.GetComponent<Canvas>().enabled = true;
            player.isEvent = true;
            Time.timeScale = 0;
        }
        else
        {
            menu.GetComponent<Canvas>().enabled = false;
            Time.timeScale = 1;
        }
    }
}
