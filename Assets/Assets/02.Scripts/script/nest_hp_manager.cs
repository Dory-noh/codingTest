using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class nest_hp_manager : MonoBehaviour
{
    public Image hp_img;
    public int hp = 0;
    bool gameover = false;
    public int Maxhp;
    public bool adeli_push;
    public Text nest_hp_text;
    // Start is called before the first frame update
    void Start()
    {
        hp_img = GameObject.FindGameObjectWithTag("nest_hp").GetComponent<Image>();
        nest_hp_text = GameObject.FindGameObjectWithTag("nest_hp_text").GetComponent<Text>();
        Maxhp = 500;
        hp = Maxhp;
    }

    // Update is called once per frame
    void Update()
    {
        nest_hp_text.text = hp.ToString() + " / " + Maxhp.ToString();
        hp_img.fillAmount = (float)hp/(float)Maxhp;
        if (hp <= 0 && gameover == false)
        {
            GameObject.FindGameObjectWithTag("ui_manager").GetComponent<ui_manager>().open_fail();
            gameover = true;

        }
    }
    IEnumerator wait()
    {
        yield return new WaitForSeconds(0.3f);
    }
    public void wait_adelie()
    {
        adeli_push = true;
        StartCoroutine(wait());
        adeli_push = false;
    }
}
