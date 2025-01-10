using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SocialPlatforms;

public class devil : MonoBehaviour
{
    public Image hp_img;
    public bool adelie_push;
    enum EnemyState
    {
        Move,
        Attack,
        Damaged,
        Die
    }
    EnemyState e_State;
    public GameObject nest;
    public GameObject nest_hp_manager;
    public CharacterController devil_cc;
    public GameObject ui_manager;
    int power;
    int maxhp;
    public int hp;
    Vector3 dir;
    bool ismove;
    bool change_img;
    int point;
    float speed;
    int exp;
    bool isNestAttack = false;
    //public bool time_changer;
    float origin_y;
    Vector3 velo = Vector3.zero;
    Vector3 targetPos;
    public Text damage_text;
    public RainEvent_manager rainEvent_Manager;
    public NestUpgrade_manager nestUpgrade_Manager;
    // Start is called before the first frame update
    void Start()
    {
        ui_manager = GameObject.FindGameObjectWithTag("ui_manager");
        adelie_push = false;
        ismove = true;
        origin_y = transform.position.y;
        if (transform.CompareTag("enemy_gull"))
        {
            maxhp = 50 + (ui_manager.GetComponent<ui_manager>().level-1) * 3; ;
            power = 6 + (ui_manager.GetComponent<ui_manager>().level - 1);
            point = 35;
            speed = 0.15f;
            exp = 3 + (ui_manager.GetComponent<ui_manager>().level - 1) * 5; ;
        }
        else if (transform.CompareTag("enemy_fox"))
        {
            maxhp = 1500 + (ui_manager.GetComponent<ui_manager>().level - 1) * 10; ;
            power = 40 + (ui_manager.GetComponent<ui_manager>().level - 1) * 2; ;
            point = 260 + (ui_manager.GetComponent<ui_manager>().level - 1) * 10; ;
            speed = 0.4f;
            exp = 150 + (ui_manager.GetComponent<ui_manager>().level - 1) * 2; ;
        }
        else if (transform.CompareTag("enemy_pelican"))
        {
            maxhp = 5500 + (ui_manager.GetComponent<ui_manager>().level - 1) * 50;
            power = 70 + (ui_manager.GetComponent<ui_manager>().level - 1) *3;
            point = 1000 + (ui_manager.GetComponent<ui_manager>().level - 1) * 10;
            speed = 0.25f;
            exp = 250 + (ui_manager.GetComponent<ui_manager>().level - 1) * 5;
        }
        hp = maxhp;
        e_State = EnemyState.Move;
        nest = GameObject.FindGameObjectWithTag("nest");
        nest_hp_manager = GameObject.FindGameObjectWithTag("nest_hp_manager");
        
        rainEvent_Manager = GameObject.FindGameObjectWithTag("event_manager").GetComponent<RainEvent_manager>();
        nestUpgrade_Manager = GameObject.FindGameObjectWithTag("event_manager").GetComponent<NestUpgrade_manager>();
        change_img = true;
        transform.GetChild(0).gameObject.SetActive(change_img);
        transform.GetChild(1).gameObject.SetActive(!change_img);
        StartCoroutine(Move());
        targetPos = new Vector3(nest.transform.position.x + 2, (nest.transform.position.y + 0.3f * origin_y), 0.35f);
        hp_img = gameObject.transform.GetComponentInChildren<Canvas>().transform.GetChild(1).GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {

        if (transform.CompareTag("enemy_gull"))
        {
            damage_text.text = hp.ToString();
        }
        //switch (e_State)
        //{
        //    case EnemyState.Move:
        //        Move();
        //        break;
        //    case EnemyState.Attack:
        //        Attack();
        //        break;
        //    case EnemyState.Damaged:
        //        //Damaged();
        //        break;
        //    case EnemyState.Die:
        //        //Die();
        //        break;
        //}
    }
    IEnumerator Move()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.06f);
            if (ismove)
            {
                transform.position = Vector3.SmoothDamp(transform.position, targetPos, ref velo, speed * 800f * Time.deltaTime);
                change_img = !change_img;
                transform.GetChild(0).gameObject.SetActive(change_img);
                transform.GetChild(1).gameObject.SetActive(!change_img);
            }
            else
            {

            }

        }
    }
    public void hit(int power)
    {
        StartCoroutine(damage(power)); //devil의 데미지를 깎는 함수
    }

    IEnumerator damage(int power)
    {

        yield return new WaitForSeconds(0.1f);
        hp -= power;
        hp = Mathf.Clamp(hp, 0, maxhp);
        if (hp <= 0) //죽음
        {
            Destroy(gameObject, 0.01f);
            ui_manager.GetComponent<ui_manager>().coin += point;
            ui_manager.GetComponent<ui_manager>().count_text.text = (++ui_manager.GetComponent<ui_manager>().count).ToString();
            ui_manager.GetComponent<ui_manager>().exp += exp*4;
            ui_manager.GetComponent<ui_manager>().exp_bar.fillAmount = (float)ui_manager.GetComponent<ui_manager>().exp / (float)ui_manager.GetComponent<ui_manager>().initExp;
            if (ui_manager.GetComponent<ui_manager>().exp_bar.fillAmount >= 1)
            {
                ui_manager.GetComponent<ui_manager>().exp_coin++;
                ui_manager.GetComponent<ui_manager>().level_text.text = (++ui_manager.GetComponent<ui_manager>().level).ToString();
                ui_manager.GetComponent<ui_manager>().exp = ui_manager.GetComponent<ui_manager>().exp- ui_manager.GetComponent<ui_manager>().initExp;
                ui_manager.GetComponent<ui_manager>().initExp *= 2;
                ui_manager.GetComponent<ui_manager>().exp_bar.fillAmount = (float)ui_manager.GetComponent<ui_manager>().exp / (float)ui_manager.GetComponent<ui_manager>().initExp;

            }
        }
        hp_img.fillAmount = (float)hp / (float)maxhp;
        if (hp_img.fillAmount <= 0.3f)
        {
            hp_img.color = Color.red;
        }
        else if (hp_img.fillAmount <= 0.5f)
        {
            hp_img.color = Color.yellow;
        }
        transform.position = new Vector3(transform.position.x + 0.23f, origin_y, transform.position.z);
        yield return new WaitForSeconds(0.1f);
        transform.position = new Vector3(transform.position.x - 0.2f, origin_y, transform.position.z);
        yield return new WaitForSeconds(0.3f);
        ismove = true;
        transform.GetChild(0).gameObject.SetActive(false);
        transform.GetChild(1).gameObject.SetActive(true);
        transform.GetChild(2).gameObject.SetActive(false);

    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        
        if (col.gameObject.CompareTag("nest"))
        {
            ismove = false;
            if (!isNestAttack)
            {
                isNestAttack = true;
                StartCoroutine(AttackNest());
            }
            
        }
        if (col.gameObject.tag.StartsWith("gull"))
        {
            ismove = false;
            col.transform.GetComponent<gull>().hit(power);
            transform.GetChild(0).gameObject.SetActive(false);
            transform.GetChild(1).gameObject.SetActive(false);
            transform.GetChild(2).gameObject.SetActive(true);
        }
        StartCoroutine(wait());
    }
    IEnumerator AttackNest()
    {
        nest_hp_manager.GetComponent<nest_hp_manager>().hp -= power;
        nest_hp_manager.GetComponent<nest_hp_manager>().hp = Mathf.Clamp(nest_hp_manager.GetComponent<nest_hp_manager>().hp, 0, nest_hp_manager.GetComponent<nest_hp_manager>().Maxhp);
        transform.GetChild(0).gameObject.SetActive(false);
        transform.GetChild(1).gameObject.SetActive(false);
        transform.GetChild(2).gameObject.SetActive(true);
        yield return new WaitForSeconds(0.3f);
        isNestAttack = false;
    }
    IEnumerator wait()
    {
        yield return new WaitForSeconds(0.3f);
    }
    //IEnumerator wait2()
    //{
    //    yield return new WaitForSeconds(1f);
    //    adelie_push = false;
    //}
    //public void wait_adelie()
    //{
    //    StartCoroutine(wait2());

    //}

}
