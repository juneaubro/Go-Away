using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitDetection : MonoBehaviour
{
    public static bool ded;
    public Animator anim;
    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            //start player death animation
            anim.SetBool("idle", false);
            anim.SetBool("death", true);

            //show death gui

            //destroy apple + player
            Destroy(this.gameObject);
            Destroy(player);

            ded = true;
        } else if(collision.gameObject.CompareTag("Shield"))
        {

            //destroy apple
            Destroy(this.gameObject);
        }
    }
}
