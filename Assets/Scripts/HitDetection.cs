using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HitDetection : MonoBehaviour
{
    public static bool ded = false;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        GameObject shield = GameObject.FindGameObjectWithTag("Shield");
        Animator anim = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
        Text scoreText = GameObject.FindGameObjectWithTag("Score").GetComponent<Text>();
        if (collision.gameObject.CompareTag("Player"))
        {
            GameObject[] applesToDestroy = GameObject.FindGameObjectsWithTag("Apples");

            ded = true;
            //player death animation
            anim.SetBool("isDead", true);
            anim.Play("death", 0);
            
            //destruction
            Destroy(player, 1);
            Destroy(shield);
            for (int i = 0; i < applesToDestroy.Length; i++) {
                Destroy(applesToDestroy[i]);
            }

            //show death screen

        } else if(collision.gameObject.CompareTag("Shield"))
        {
            ScoreManager.currentScore++;
            scoreText.text = "Score: " + ScoreManager.currentScore;
            Destroy(this.gameObject);
        }
    }
}
