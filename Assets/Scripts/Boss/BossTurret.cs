using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossTurret : MonoBehaviour
{
    //this script uses rigidbody2D of the projectile and shoots it with AddForce. 
    public float shootForce = 3500f;
    public float fireRate = 0.4f;
    private float nextFire;
    public Rigidbody2D rb;
    public Transform AttackSpawn; //it takes into consideration the rotation of transform spawn

    //rotation variables
    float turnSpeed = 45f;
    private bool changeDir = false;
    float turnTime = 1.6f;
    float doubleTurnTime;  //needed for after first turn

    void Start()
    {
        doubleTurnTime = 2 * turnTime;
        StartCoroutine(Turn());
    }
    void Shoot()
    {
        if (Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            var Projectile = Instantiate(rb, AttackSpawn.position, AttackSpawn.rotation);
            Projectile.AddForce(-AttackSpawn.right * shootForce);
        }
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

        Shoot();
    }
    IEnumerator Turn()
    {
        yield return new WaitForSeconds(turnTime);
        if(changeDir == false)
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
