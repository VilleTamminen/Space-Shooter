using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooter : MonoBehaviour
{
    //this script uses rigidbody2D of the projectile and shoots it with AddForce. 
    public float shootForce = 3500f;
    public float fireRate = 2f;
    private float nextFire;
    public Rigidbody2D rb;
    public Transform AttackSpawn; //it takes into consideration the rotation of transform spawn

    void Shoot()
    {
        if(Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            var Projectile = Instantiate(rb, AttackSpawn.position, AttackSpawn.rotation);
            Projectile.AddForce(AttackSpawn.up * shootForce);
        }
    }
    void Update()
    {
        Shoot();
    }
}
