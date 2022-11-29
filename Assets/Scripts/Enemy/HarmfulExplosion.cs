using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HarmfulExplosion : MonoBehaviour
{
    //this explosion harms everyone, both player and enemies
    float damage = 250;
    private float explosionGrowTime = 0.6f;
    private float explosionShrinkTime = 0.8f;
    private bool growing = true;

    void Start()
    {
        StartCoroutine(TimeToGrow());
    }
    void Update()
    {
        if (growing == true)  //explosion will grow slighty faster and then shrink. 
        {
            transform.localScale += new Vector3(0.20F, 0.20F, 0); //growth speed
        }
        if (growing == false)  //explosion will shrink
        {
            StartCoroutine(TimeToShrink());
            transform.localScale -= new Vector3(0.15F, 0.15F, 0); //shrink speed
        }
    }
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Player" && Player.invincible == false)
        {
            HealthbarScript.health -= damage;
        }
        if (collider.tag == "Enemy")
        {
            collider.GetComponent<EnemyCollider>().TakeDamage(damage);
        }
    }
    IEnumerator TimeToGrow()
    {
        yield return new WaitForSeconds(explosionGrowTime);
        growing = false;
    }
    IEnumerator TimeToShrink()
    {
        yield return new WaitForSeconds(explosionShrinkTime);  //destroy this object after some time
        Destroy(gameObject);
    }
}
