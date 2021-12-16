using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleSpawn : MonoBehaviour
{
    public GameObject apple;
    bool pause = !false;
    float appleDelay = 2f;
    float appleSpeed = .3f;
    float delayTime = 2f;
    public float minX, maxX, minY, maxY;
    void Start()
    {
        SpawnApple();
    }

    void SpawnApple()
    {
        if (HitDetection.ded == false)
        {
            GameObject temp;
            int randomValue = Random.Range(0, 4);

            switch (randomValue)
            {
                //top wall
                case 0:
                    //spawn apple with random starting rotation at border
                    temp = Instantiate(apple, new Vector3(Random.Range(minX, maxX), maxY, 0), Quaternion.Euler(new Vector3(0, 0, Random.Range(0, 360))));
                    //add velocity to 'push' apple to 0,0,0 at appleSpeed
                    temp.GetComponent<Rigidbody2D>().velocity = -Vector2.Lerp(temp.transform.position, Vector2.zero, -.03f) * appleSpeed;
                    //YOU SPIN ME RIGHT ROUND BABY
                    temp.GetComponent<Rigidbody2D>().angularVelocity = Random.Range(-360, 360);
                    break;
                //bottom wall
                case 1:
                    temp = Instantiate(apple, new Vector3(Random.Range(minX, maxX), minY, 0), Quaternion.Euler(new Vector3(0, 0, Random.Range(0, 360))));
                    temp.GetComponent<Rigidbody2D>().velocity = -Vector2.Lerp(temp.transform.position, Vector2.zero, -.03f) * appleSpeed;
                    temp.GetComponent<Rigidbody2D>().angularVelocity = Random.Range(-360, 360);
                    break;
                //left wall
                case 2:
                    temp = Instantiate(apple, new Vector3(minX, Random.Range(minY, maxY), 0), Quaternion.Euler(new Vector3(0, 0, Random.Range(0, 360))));
                    temp.GetComponent<Rigidbody2D>().velocity = -Vector2.Lerp(temp.transform.position, Vector2.zero, -.03f) * appleSpeed;
                    temp.GetComponent<Rigidbody2D>().angularVelocity = Random.Range(-360, 360);
                    break;
                //right wall
                case 3:
                    temp = Instantiate(apple, new Vector3(maxX, Random.Range(minY, maxY), 0), Quaternion.Euler(new Vector3(0, 0, Random.Range(0, 360))));
                    temp.GetComponent<Rigidbody2D>().velocity = -Vector2.Lerp(temp.transform.position, Vector2.zero, -.03f) * appleSpeed;
                    temp.GetComponent<Rigidbody2D>().angularVelocity = Random.Range(-360, 360);
                    break;
                default:
                    break;
            }
            // RECURSION BBY
            Invoke("SpawnApple", appleDelay);
        }
    }

    public void Update()
    {
        if(pause && appleDelay > 0.3f)
            StartCoroutine(appleSpeedIncrease());
    }

    public IEnumerator appleSpeedIncrease()
    {
        if (HitDetection.ded == false)
        {
            //NO TOUCH GO AWAY
            pause = !pause;
            yield return new WaitForSecondsRealtime(delayTime);
            delayTime *= 2;
            Debug.Log(delayTime + " : " + appleDelay);
            appleDelay -= .3f;
            pause = !pause;
        }
    }
}
