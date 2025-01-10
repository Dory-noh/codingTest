using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NestCollider : MonoBehaviour
{
    BoxCollider2D boxCollider;
    void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        StartCoroutine(ColliderOnOff());
    }

    IEnumerator ColliderOnOff()
    {
        while (true)
        {
            boxCollider.enabled = true;
            yield return new WaitForSeconds(0.3f);
            boxCollider.enabled = false;
            yield return new WaitForSeconds(0.3f);
        }
        
    }
}
