using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleSpawn : MonoBehaviour
{
    float integer = 2f;
    bool pause =  !false;
    float appleSpeed = .3f;
    public GameObject apple;
    float appleDelay = 2f;
    public float minX, maxX, minY, maxY;
    void Start()
    {
        SpawnApple();
    }

    void SpawnApple()
    {
        GameObject temp;
        int randomValue = Random.Range(0, 4);
        switch(randomValue)
        {
            //top wall
            case 0:
                temp = Instantiate(apple, new Vector3(Random.Range(minX, maxX), maxY, 0), Quaternion.identity);
                temp.GetComponent<Rigidbody2D>().velocity = -Vector2.Lerp(temp.transform.position,Vector2.zero, -.03f) * appleSpeed;
                break;
            //bottom wall
            case 1:
                temp = Instantiate(apple, new Vector3(Random.Range(minX, maxX), minY, 0), Quaternion.identity);
                temp.GetComponent<Rigidbody2D>().velocity = -Vector2.Lerp(temp.transform.position, Vector2.zero, -.03f) * appleSpeed;
                break;
                //left wall
            case 2:
                temp = Instantiate(apple, new Vector3(minX, Random.Range(minY, maxY), 0), Quaternion.identity);
                temp.GetComponent<Rigidbody2D>().velocity = -Vector2.Lerp(temp.transform.position, Vector2.zero, -.03f) * appleSpeed;
                break;
                //right wall
            case 3:
                temp = Instantiate(apple, new Vector3(maxX, Random.Range(minY, maxY), 0), Quaternion.identity);
                temp.GetComponent<Rigidbody2D>().velocity = -Vector2.Lerp(temp.transform.position, Vector2.zero, -.03f) * appleSpeed;
                break;
            default:
                break;
        }
        Invoke("SpawnApple", appleDelay);
    }

    public void Update()
    {
        if(pause && appleDelay > 0.3f)
        StartCoroutine(appleSpeedIncrease());
    }

    public IEnumerator appleSpeedIncrease()
    {
        //NO TOUCH GO AWAY
        pause = !pause;
        yield return new WaitForSecondsRealtime(integer);
        integer *= 2;
        Debug.Log(integer +  " : " + appleDelay);
        appleDelay -= .3f;
        pause = !pause;
    }
}
