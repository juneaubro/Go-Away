using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitDetection : MonoBehaviour
{
    public static bool ded;
    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Apples"))
        {
            //start playing death animation here lo

            //ensure to always keep gameObject
            Destroy(this.gameObject);
            ded = true;
        }
    }
}
