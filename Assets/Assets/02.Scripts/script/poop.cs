using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class poop : MonoBehaviour
{
    Rigidbody2D rb;
    int power;
    int speed;
    float timeTerm = 0.5f;
    private void Start()
    {
        rb = transform.GetComponent<Rigidbody2D>();
        speed = 140;
        power = 8;
        StartCoroutine(move());
    }
    IEnumerator move()
    {
        yield return new WaitForSeconds(0.1f);
        rb.AddForce(Vector3.right*speed);
        //if(Vector3.Distance(gull.transform.position,))
        Destroy(gameObject, 4f);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        
        if (col.gameObject.tag.StartsWith("enemy"))
        {
            StartCoroutine(HitReady(col));
            Destroy(gameObject,5f);
        }
    }

    private IEnumerator HitReady(Collider2D col)
    {
        int count = 0;
        while (count < 4 && col!=null)
        {
            col.transform.GetComponent<devil>().hit(power);
            yield return new WaitForSeconds(timeTerm);
            count++;
            //Debug.Log(count);
        }   

        
    }
}
