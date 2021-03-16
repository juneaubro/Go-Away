using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class REnemyL1 : MonoBehaviour
{
    public float attackWindow;

    private float delay;

    public static bool attacked;

    public void Start()
    {
        delay = Random.Range(1.8f, 6.5f);
    }

    //public void Update()
    //{
    //    attack();

    //    Time.frameCount
    //}

    //public IEnumerator attack()
    //{
    //    yield return new WaitForSeconds(delay);

    //    attacked = true;

    //    yield return new WaitForSeconds();
    //}
}
