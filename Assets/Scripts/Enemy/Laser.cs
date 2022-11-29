using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    float damage = 10;
    //rotation variables
    public float turnSpeed = 45f;
    private bool changeDir = false;
    public float turnTime = 1.6f;
    float doubleTurnTime;  //needed for after first turn

    void Start()
    {
        doubleTurnTime = 2 * turnTime;
        StartCoroutine(Turn());
    }
    void Update()
    {
        if (changeDir == false)
        {
            transform.Rotate(Vector3.forward * turnSpeed * Time.deltaTime);
        }
        if (changeDir == true)
        {
            transform.Rotate(-Vector3.forward * turnSpeed * Time.deltaTime);
        }
    }
    void OnTriggerStay2D(Collider2D col)
    {
        if(col.tag == "Player")
        {
            HealthbarScript.health -= damage;
        }
    }
    IEnumerator Turn()
    {
        yield return new WaitForSeconds(turnTime);
        if (changeDir == false)
        {
            changeDir = true;
            turnTime = doubleTurnTime;
            StartCoroutine(Turn());
        }
        else
        {
            changeDir = false;
            turnTime = doubleTurnTime;
            StartCoroutine(Turn());
        }
    }
}
