using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera_manager : MonoBehaviour
{
    public GameObject main_camera;
    public GameObject left_btn;
    public GameObject right_btn;
    public float moveSpeed = 10f;
    public float min = -1f;
    public float max = 30f;
    private float[] pointXArr;
    private int idx = 0;
    // Start is called before the first frame update
    void Start()
    {
        pointXArr = new float[] { min, (min + max) / 2, max };
        main_camera = GameObject.FindGameObjectWithTag("MainCamera");
        left_btn = GameObject.FindGameObjectWithTag("left_btn");
        right_btn = GameObject.FindGameObjectWithTag("right_btn");
        main_camera.transform.position = new Vector3(-1, 2f, -20f);
        left_btn.SetActive(false);
        right_btn.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        float moveAmount = Input.GetAxis("Mouse ScrollWheel")*moveSpeed;
        float distance = main_camera.transform.position.x - moveAmount;
        distance = Mathf.Clamp(distance, min, max);
        main_camera.transform.position = new Vector3(distance,main_camera.transform.position.y,main_camera.transform.position.z);
        idx = Mathf.Clamp(idx, 0, 2);
        if(idx == 0)
        {
            left_btn.SetActive(false);
            right_btn.SetActive(true);
        }
        else if(idx == 1)
        {
            left_btn.SetActive(true);
            right_btn.SetActive(true);
        }
        else
        {
            left_btn.SetActive(true);
            right_btn.SetActive(false);
        }
        main_camera.transform.position = new Vector3(pointXArr[idx], 2f, -20f);
    }
    public void move_camera_left()
    {
        idx--;
    }
    public void move_camera_right()
    {
        idx++;
    }
}
