using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossLaser : MonoBehaviour
{
    public GameObject laser;
    public GameObject effect;
    public Transform spawnPoint;
    public float fireRate = 10f;

    void Start()
    {
        StartCoroutine(Shoot());
        StartCoroutine(Effect());
    }

    void Fire() //instantiate laser
    {
        GameObject a = Instantiate(laser, spawnPoint.position, spawnPoint.rotation);
        StartCoroutine(DestroyObject(a, 6f));        
    }
    void StartEffect() //instantiate laser
    {
        GameObject b = Instantiate(effect, spawnPoint.position, spawnPoint.rotation);
        StartCoroutine(DestroyObject(b, 7.5f));
    }


    IEnumerator Shoot()
    {
        yield return new WaitForSeconds(fireRate);
        Fire();
        StartCoroutine(Shoot()); //start waiting for next attack
        StartCoroutine(Effect()); //start waiting for next effect
    }
    IEnumerator Effect()
    {
        yield return new WaitForSeconds(fireRate - 1.5f);
        StartEffect();
    }
    IEnumerator DestroyObject(GameObject obj, float time) //destroy laser
    {
        yield return new WaitForSeconds(time);
        Destroy(obj);
    }
}
