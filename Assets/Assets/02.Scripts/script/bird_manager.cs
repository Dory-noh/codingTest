using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class bird_manager : MonoBehaviour
{
    public GameObject gull_prefab;
    public GameObject ui_manager;
    int coin;
    public float time;
    bool[] is_respawn = { true, true, true, true, true };
    public int gull_num;
    public Image respawn_btn_img;
    float time_space;
    private readonly string[] gullNames = { "gull_b1", "gull_b2", "gull_b3", "gull_b4", "gull_b5" };
    private readonly float[] respawnTimes = {0.4f,0.6f,1f,1.6f,3f };
    // Start is called before the first frame update
    void Start()
    {
        ui_manager = GameObject.FindGameObjectWithTag("ui_manager");
        respawn_btn_img = GameObject.FindGameObjectWithTag(("respawn_btn" + gull_num.ToString())).GetComponent<Image>();
        respawn_btn_img.fillAmount = 1;
        time_space = 0;
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < gullNames.Length; i++) {
            if (gull_prefab.transform.CompareTag(gullNames[i]))
            {
                time = respawnTimes[i];
                break;
            }
        }
        
    }

    IEnumerator respawn_gull()
    {
        float y = Random.Range(-0.5f, 2);
        yield return new WaitForSeconds(time);
        GameObject gull = Instantiate(gull_prefab);
        gull.transform.position = new Vector3(-10.55f, y, 0.35f);
        is_respawn[gull_num] = true;
    }
    public void respawn_gull_btn(int price)
    {
        int coin = ui_manager.GetComponent<ui_manager>().coin;
        int temp = coin - price;
        if (temp >= 0 && is_respawn[gull_num])
        {
            StartCoroutine(fill_btn_img());
            is_respawn[gull_num] = false;
            ui_manager.GetComponent<ui_manager>().coin = temp;
            StartCoroutine(respawn_gull());
        }

        
    }
    IEnumerator fill_btn_img()
    {
        respawn_btn_img.fillAmount = 0;
        time_space = 0;
        while (respawn_btn_img.fillAmount < 1)
        {
            respawn_btn_img.fillAmount = time_space / (float)time;
            time_space += Time.deltaTime;
            yield return new WaitForSecondsRealtime(0.001f);
        }
    }
}
