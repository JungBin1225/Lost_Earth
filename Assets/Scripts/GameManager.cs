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

    public Image menu;
    public Image menuLayer;

    public float Hp = 100;
    public float O2 = 100;
    public float temp = 30.0f;

    public bool[] first_Lock = { false, false, false };
    public int first_Lock_num = 0;
    public bool soup = false;
    public bool stop = false;

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
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        hp_Gauge = GameObject.Find("hp_gauge");
        O2_Gauge = GameObject.Find("O2_gauge");
        Temp_Gauge = GameObject.Find("Temp_gauge");
        O2_state = GameObject.Find("O2_state");
        Temp_state = GameObject.Find("Temp_state");

        menu = GameObject.Find("Menu").GetComponent<Image>();
        menuLayer = GameObject.Find("Layer").GetComponent<Image>();

        if (O2 <= 0) //산소 최소치 0%
        {
            if(O2 != 0)
            {
                O2 = 0;
            }
            Hp -= 1.0f * Time.deltaTime;
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

        hp_Gauge.GetComponent<Image>().fillAmount = Hp / 100; //UI에 현재 Hp, 산소, 온도를 표시
        O2_Gauge.GetComponent<Image>().fillAmount = O2 / 100;
        Temp_Gauge.GetComponent<Image>().fillAmount = (temp - 10) / 55;
        O2_state.GetComponent<Text>().text = O2.ToString("F0") + "%";
        Temp_state.GetComponent<Text>().text = temp.ToString("F1") + "ºC";

        if(Input.GetKeyUp(KeyCode.Escape)) //ESC 누르면 일시정지
        {
            stop = !stop;
            player.isEvent = !player.isEvent;
        }


        if(stop) //일시정지 하면 게임 종료 메뉴 등장
        {
            menu.color = new Color(menu.color.r, menu.color.g, menu.color.b, 0.7f);
            menuLayer.color = new Color(menuLayer.color.r, menuLayer.color.g, menuLayer.color.b, 0.7f);
            Time.timeScale = 0;
        }
        else
        {
            menu.color = new Color(menu.color.r, menu.color.g, menu.color.b, 0);
            menuLayer.color = new Color(menuLayer.color.r, menuLayer.color.g, menuLayer.color.b, 0);
            Time.timeScale = 1;
            
        }
    }

}
