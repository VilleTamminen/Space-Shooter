using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedDeath : MonoBehaviour
{
    public float timeTolive = 30f;
    void Start()
    {
        StartCoroutine(TimeToLive());
    }

    IEnumerator TimeToLive()
    {
        yield return new WaitForSeconds(timeTolive);  //wait sometime before death. we don't want these to stay alive too long
        Destroy(gameObject);
    }
}
