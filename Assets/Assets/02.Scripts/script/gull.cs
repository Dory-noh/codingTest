using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class gull : MonoBehaviour
{
    public bool adelie_push;
    public Image hp_img;
    bool ismove;
    float hp;
    int maxhp;
    int power;
    bool change_img;
    float speed;
    //public bool time_changer;
    Vector3 velo = Vector3.zero;
    Vector3 targetPos;
    public int respawn_time;//소환까지 걸리는 시간
    float origin_y;
    

    void Start()
    {
        adelie_push = false;
        origin_y = transform.position.y;
        if (transform.CompareTag("gull_b1"))
        {
            maxhp = 50;
            power = 10;
            speed = 0.1f;
        }
        if (transform.CompareTag("gull_b2"))
        {
            maxhp = 150;
            power = 20;
            speed = 0.2f;
        }
        if (transform.CompareTag("gull_b3"))
        {
            maxhp = 200;
            power = 10;
            speed = 0.2f;
            adelie_push = true; //위치가 너무 이상해져서 아델리의 푸시공격 당하지 않도록 설정함.
        }
        if (transform.CompareTag("gull_b4"))
        {
            maxhp = 400;
            power = 20;
            speed = 0.2f;
        }
        if (transform.CompareTag("gull_b5"))
        {
            maxhp = 150;
            power = 250;
            speed = 0.2f;
        }
        hp = maxhp;
        ismove = true;
        StartCoroutine(move());
        change_img = true;
        transform.GetChild(0).gameObject.SetActive(change_img);
        transform.GetChild(1).gameObject.SetActive(!change_img);
        hp_img = gameObject.transform.GetComponentInChildren<Canvas>().transform.GetChild(1).GetComponent<Image>();
        if (transform.CompareTag("gull_b3"))
        {
            targetPos = new Vector3(43.44f, origin_y, 0.35f);
        }
        else targetPos = new Vector3(40.44f, origin_y, 0.35f);
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.CompareTag("gull_b3"))
        {
            if ((targetPos.x - gameObject.transform.position.x) < 2.0f)
            {
                Destroy(gameObject);
            }
        }
    }

    IEnumerator move()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.06f);
            if (ismove)
            {
                transform.position = Vector3.SmoothDamp(transform.position, targetPos, ref velo, speed * 1200f*Time.deltaTime);
                change_img = !change_img;
                transform.GetChild(0).gameObject.SetActive(change_img);
                transform.GetChild(1).gameObject.SetActive(!change_img);
                //if(Vector3.Distance(gull.transform.position,))
            }
            else
            {

            }

        }
    }
    public void hit(int power)
    {
        StartCoroutine(damage(power)); //gull의 데미지를 깎는 함수
        
        
    }

    IEnumerator damage(int power)
    {
        yield return new WaitForSeconds(0.1f);
        hp -= power;
        hp = Mathf.Clamp(hp, 0, maxhp);
        if (hp <= 0) Destroy(gameObject, 0.01f);
        hp_img.fillAmount = (float)hp / (float)maxhp;
        if (hp_img.fillAmount <= 0.3f)
        {
            hp_img.color = Color.red;
        }
        else if (hp_img.fillAmount <= 0.5f)
        {
            hp_img.color = Color.yellow;
        }
        transform.position = new Vector3(transform.position.x - 0.23f, origin_y, transform.position.z);
        yield return new WaitForSeconds(0.1f);
        transform.position = new Vector3(transform.position.x + 0.2f, origin_y, transform.position.z);
        yield return new WaitForSeconds(0.3f);
        ismove = true;
        transform.GetChild(0).gameObject.SetActive(false);
        transform.GetChild(1).gameObject.SetActive(true);
        transform.GetChild(2).gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag.StartsWith("enemy"))
        {
            ismove = false;
            col.transform.GetComponent<devil>().hit(power);
            transform.GetChild(0).gameObject.SetActive(false);
            transform.GetChild(1).gameObject.SetActive(false);
            transform.GetChild(2).gameObject.SetActive(true);
        }

        StartCoroutine(wait());
    }

    IEnumerator wait()
    {
        yield return new WaitForSeconds(0.3f);
    }
    IEnumerator wait2()
    {
        yield return new WaitForSeconds(1f);
        adelie_push = false;
    }
    public void wait_adelie()
    {
        StartCoroutine(wait2());
        
    }
}
