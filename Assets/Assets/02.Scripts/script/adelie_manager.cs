using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class adelie_manager : MonoBehaviour
{
    int day;
    public GameObject adelie_prefab;
    bool respawn_adelie_ok;
    public int dir;
    public List<Vector3> pos = new List<Vector3>();
    public bool goAdelie = false;
    // Start is called before the first frame update
    void Start()
    {
        //respawn_adelie_repeat();
        //respawn_adelie_ok = true;
    }

    // Update is called once per frame
    void Update()
    {
        //day = GameObject.FindGameObjectWithTag("ani_manager").GetComponent<ani_manager>().day;
        //if (day == 1 && respawn_adelie_ok)
        //{
        //    respawn_adelie_repeat();
        //    respawn_adelie_ok = false;
        //}
        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    RespawnAdelie();
        //}
    }

    public void RespawnAdelie()
    {
        if(goAdelie == true)
        {
            goAdelie = false;
            //int time = Random.Range(10, 40);
            float y = Random.Range(-0.5f, 2);
            //dir = Random.Range(0, 2); //0:좌 / 1:우 위치에 배치
            GameObject adelie = Instantiate(adelie_prefab);
            //if (dir == 0)
            adelie.transform.localScale = new Vector3(-1, 1, 1);
            //if (pos.Count == 0)
            //{
            //    pos.Add(new Vector3(-10.55f, y, 0.35f));
            //    pos.Add(new Vector3(37, y, 0.35f));
            //}
            //else
            //{
            //    pos[0] = (new Vector3(-10.55f, y, 0.35f));
            //    pos[1] = (new Vector3(37, y, 0.35f));
            //}
            //adelie.transform.position = pos[dir];
            adelie.transform.position = new Vector3(-10.55f, y, 0.35f); 
        }
        
    }

    //IEnumerator respawn_adelie()
    //{
    //    while (true)
    //    {
    //        int time = Random.Range(10, 40);
    //        yield return new WaitForSeconds(time);
    //        for (int i = 0; i < 3; i++) {
    //            int y = Random.Range(-1, 2);
    //            dir = Random.Range(0, 2); //0:좌 / 1:우 위치에 배치
    //            GameObject adelie = Instantiate(adelie_prefab);
    //            if (dir == 0) adelie.transform.localScale = new Vector3(-1, 1, 1);
    //            if (pos.Count == 0)
    //            {
    //                pos.Add(new Vector3(-10.55f, y, 0.35f));
    //                pos.Add(new Vector3(37, y, 0.35f));
    //            }
    //            else
    //            {
    //                pos[0] = (new Vector3(-10.55f, y, 0.35f));
    //                pos[1] = (new Vector3(37, y, 0.35f));
    //            }
    //            adelie.transform.position = pos[dir];
    //            yield return new WaitForSeconds(0.3f);
    //        }

    //    }
    //}
    //void respawn_adelie_repeat()
    //{
    //    StartCoroutine(respawn_adelie());
    //}
}
