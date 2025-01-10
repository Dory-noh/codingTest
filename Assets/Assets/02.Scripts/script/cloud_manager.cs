using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cloud_manager : MonoBehaviour
{

    public GameObject cloud_obj;
   // int x;
    // Start is called before the first frame update
    void Start()
    {
        //x = 3;
        StartCoroutine(move_cloud());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public IEnumerator move_cloud()
    {
        cloud_obj.transform.position = new Vector3(-24.74f, 4.04f, -4.745f);
        while (true)
        {
            cloud_obj.transform.position = Vector3.Lerp(cloud_obj.transform.position, new Vector3(35f, 4.04f, -4.745f), 0.03f * 5f);
            yield return new WaitForSeconds(0.3f);
            if(Vector3.Distance (cloud_obj.transform.position,new Vector3(35f, 4.04f, -4.745f))< 3f) cloud_obj.transform.position = new Vector3(-24.74f, 4.04f, -4.745f);
        }
        
    }
}
