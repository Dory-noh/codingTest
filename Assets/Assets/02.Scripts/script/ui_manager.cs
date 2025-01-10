using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;

public class ui_manager : MonoBehaviour
{
    public static ui_manager instance;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }
    public GameObject window_img;
    public GameObject success_img;
    public GameObject fail_img;
    public Text scoreTxt;
    public Text coin_text;
    public int coin;
    public Text exp_coin_text;
    public int exp_coin;
    public int exp;
    public int initExp = 15;
    public Image exp_bar;
    public int level;
    public Text level_text;
    public int count; //Á×ÀÎ ÀûÀÇ ¼ö
    public Text count_text;
    bool isPause = false;

    private readonly string eventManagerTag = "event_manager";
    private readonly string adelieManagerTag = "adelie_manager";

    [SerializeField]private RainEvent_manager rainEvent_manager;
    [SerializeField]private NestUpgrade_manager nestUpgrade_manager;
    [SerializeField] private adelie_manager adelie_Manager;
    [SerializeField] private ani_manager ani_manager;
    // Start is called before the first frame update
    void Start()
    {
        
        window_img.SetActive(false);
        success_img.SetActive(false);
        fail_img.SetActive(false);
        coin = 130;
        exp_coin = 0;
        exp = 0;
        level = 1;
        exp_bar = GameObject.FindGameObjectWithTag("exp_bar").GetComponent<Image>();
        level_text = GameObject.FindGameObjectWithTag("LEVELTXT").GetComponent<Text>();
        level_text.text = level.ToString();
        exp_bar.fillAmount = exp;
        count = 0;
        count_text = GameObject.FindGameObjectWithTag("count_txt").GetComponent<Text>();
        rainEvent_manager = GameObject.FindGameObjectWithTag(eventManagerTag).GetComponent<RainEvent_manager>();
        nestUpgrade_manager = GameObject.FindGameObjectWithTag(eventManagerTag).GetComponent<NestUpgrade_manager>();
        adelie_Manager = GameObject.FindGameObjectWithTag(adelieManagerTag).GetComponent<adelie_manager>();
        scoreTxt = fail_img.transform.GetChild(0).GetChild(1).GetComponent<Text>();
        ani_manager = GameObject.FindWithTag("ani_manager").GetComponent<ani_manager>();
    }
    public void Skill_btn(int skillNum)
    {
        int temp;
        if(skillNum == 0)
        {
            temp = exp_coin - 1;
            if (temp >= 0)
            {
                nestUpgrade_manager.canUpgrade = true;
                exp_coin -= 1;
                nestUpgrade_manager.UpgradeNestHp();
            }
        }
        else if (skillNum == 1) 
        {
            temp = exp_coin - 2;
            if (temp >= 0)
            {
                rainEvent_manager.canRain = true;
                exp_coin -= 1;
                rainEvent_manager.dropRainEvent();
            }
        }
        else if(skillNum ==2){
            temp = exp_coin - 2;
            if (temp >= 0)
            {
                
                adelie_Manager.goAdelie = true;
                exp_coin -= 2;
                adelie_Manager.RespawnAdelie();
            }
        }
        


    }
    // Update is called once per frame
    void Update()
    {
        coin_text.text = coin.ToString();
        exp_coin_text.text = exp_coin.ToString();
        if (Application.platform == RuntimePlatform.Android)
        {
            if (Input.GetKeyUp(KeyCode.Escape))
            {
                Pause(true);
            }
        }
        if(Application.platform == RuntimePlatform.WindowsEditor)
        {
            if (Input.GetKeyUp(KeyCode.Escape))
            {
                isPause = !isPause;
                Pause(!isPause);
            }
        }
    }
    public void Pause(bool isPause)
    {
        if (isPause)
        {
            open_window();
        }
        else
        {
            close_window();
        }
    }
    public void speed_slow()
    {
        Time.timeScale = 0.5f;
    }
    public void speed_fast()
    {
        Time.timeScale = 2f;
    }
    public void open_window()
    {
        window_img.SetActive(true);
        Time.timeScale = 0f;
    }
    public void close_window()
    {
        window_img.SetActive(false);
        Time.timeScale = 1f;
    }
    public void open_success()
    {
        Time.timeScale = 0;
        success_img.SetActive(true);
    }
    public void close_success()
    {
        success_img.SetActive(false);
    }
    public void open_fail()
    {
        Time.timeScale = 0;
        scoreTxt.text = $"Score: {count} Day: {ani_manager.day}";
        fail_img.SetActive(true);
    }
    public void close_fail()
    {
        fail_img.SetActive(false);
    }
    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void Backtohome()
    {
        SceneManager.LoadScene(0);
    }
}
