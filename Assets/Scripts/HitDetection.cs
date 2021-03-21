using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitDetection : MonoBehaviour
{
    public static bool ded = false;
    public static int score;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            GameObject[] applesToDestroy = GameObject.FindGameObjectsWithTag("Apples");
            ded = true;
            //start player death animation
            
            for (int i = 0; i < applesToDestroy.Length; i++) {
                Destroy(applesToDestroy[i]);
            }
            Destroy(player);

            //show death screen

        } else if(collision.gameObject.CompareTag("Shield"))
        {
            Destroy(this.gameObject);

            score++;
        }
    }
}
