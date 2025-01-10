using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class adelie : MonoBehaviour
{
    float speed = 0.1f;
    public Vector3 pos;
    public int dir;
    GameObject adelie_manager;
    private Rigidbody2D rb;
    public GameObject nest_hp_manager;
    public bool adeli_push;
    public Vector3 velo = Vector3.zero;
    public Vector3 targetPos;
    float y = 0;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        adelie_manager = GameObject.FindGameObjectWithTag("adelie_manager");
        //dir = adelie_manager.GetComponent<adelie_manager>().dir == 0 ? 1 : 0; // 변환된 dir = 1 -> 오른쪽으로 이동, dir = 0 -> 왼쪽으로 이동
        //pos = adelie_manager.GetComponent<adelie_manager>().pos[dir];
        nest_hp_manager = GameObject.FindGameObjectWithTag("nest_hp_manager");
        StartCoroutine(Move());
        y = Random.Range(-0.5f, 2);
        pos = new Vector3(42, y, 0.35f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator Move()
    {
        while (true)
        {
            yield return new WaitForSeconds(speed);
            transform.position = Vector3.Lerp(transform.position, pos, 0.01f * 2f);
            //rb.AddForce(Vector2.right);
            if (Vector3.Distance(transform.position, pos) < 3) Destroy(gameObject);
            //change_img = !change_img;
            //transform.GetChild(0).gameObject.SetActive(change_img);
            //transform.GetChild(1).gameObject.SetActive(!change_img);
            //if(Vector3.Distance(gull.transform.position,))


        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("nest") )
        {
            adeli_push = nest_hp_manager.GetComponent<nest_hp_manager>().adeli_push;
            if (!adeli_push)
            {
                nest_hp_manager.GetComponent<nest_hp_manager>().hp -= 2;
                nest_hp_manager.GetComponent<nest_hp_manager>().wait_adelie();
            }
            
        }
        else
        {
            //if (other.gameObject.tag.StartsWith("gull"))
            //{
            //    adeli_push = other.transform.GetComponent<gull>().adelie_push;
            //}
            if (other.gameObject.tag.StartsWith("enemy"))
            {
                adeli_push = other.transform.GetComponent<devil>().adelie_push;
            }
            if (!adeli_push)
            {
                // y값이 일정값보다 크거나 작으면 y값 조정을 하지 않는다. 쿨타임 후 다시 밀칠 수 있도록 한다.
                float x = 1;
                float y = 1;
                if (dir == 0) x *= -1;
                if (other.gameObject.transform.position.y < gameObject.transform.position.y)
                {
                    y *= -1;
                    if (other.gameObject.transform.position.y < -0.65f) y = 0;
                }
                else
                {
                    if (other.gameObject.transform.position.y > 1.5f) y = 0;
                }
                //if (other.gameObject.tag.StartsWith("gull") && other.GetComponent<gull>().adelie_push == false)
                //{
                //    other.GetComponent<gull>().adelie_push = true;
                //    targetPos = other.gameObject.transform.position + new Vector3(x * 10, y * 5, 0);
                //    other.gameObject.transform.position = Vector3.SmoothDamp(other.transform.position, targetPos, ref velo, 0.1f);
                //    other.GetComponent<gull>().wait_adelie();

                //}
                if (other.gameObject.tag.StartsWith("enemy"))// && other.GetComponent<devil>().adelie_push == false
                {
                    //other.GetComponent<devil>().adelie_push = true;
                    if (other.gameObject.transform.position.x < -0.8f) x = 0;
                    other.gameObject.transform.position=new Vector3(other.gameObject.transform.position.x+1f , other.gameObject.transform.position.y, other.gameObject.transform.position.z);
                    //other.GetComponent<devil>().wait_adelie();
                }
            }
        }
        
    }
}
