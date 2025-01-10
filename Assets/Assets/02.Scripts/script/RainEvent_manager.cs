using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class RainEvent_manager : MonoBehaviour
{
    public GameObject rain_prefab;
    public Button rain_btn;
    public bool canRain = false;
    private readonly string rainBtn = "RAINBTN";
    void Start()
    {
        rain_btn = GameObject.FindGameObjectWithTag(rainBtn).GetComponent<Button>();
    }

    void Update()
    {

    }


    public void dropRainEvent()
    {
        if(canRain == true)
        {
            canRain = false;
            for (int i = 0; i < 4; i++)
                StartCoroutine(DropRain());
        }
        
    }
    IEnumerator DropRain()
    {
        float time = Random.Range(0, 0.1f);
        for (int i = 0; i < 50; i++)
        {
            float x = 0, y = 0;

            x = Random.Range(-10, 40);
            y = Random.Range(10, 20);
            Vector2 pos = new Vector2(x, y);
            GameObject rain = Instantiate(rain_prefab);
            rain.transform.position = pos;
        }
        yield return new WaitForSeconds(time);
    }



}
