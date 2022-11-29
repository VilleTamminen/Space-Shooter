using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketExplosion : MonoBehaviour
{
    //Explosion size can be changed with growth time and speed
    private float explosionDamage = 800;  //previously int
    private float explosionGrowTime = 0.6f;
    private float explosionShrinkTime = 0.78f;
    private bool growing = true;

    void Start()
    {
        StartCoroutine(TimeToGrow());
    }
    void Update()
    {
        if (growing == true)  //explosion will grow slighty faster and then shrink. 
        {  
            transform.localScale += new Vector3(0.13F, 0.13F, 0); //growth speed
        }
        if (growing == false)  //explosion will shrink
        {
            StartCoroutine(TimeToShrink());
            transform.localScale -= new Vector3(0.1F, 0.1F, 0); //shrink speed
        }
    }
    void OnTriggerEnter2D(Collider2D collider)  //collision ei toimi jos vihollisella ei ole rigidbody2D:tä
    {
        if (collider.tag == "Enemy")
        {
            collider.GetComponent<EnemyCollider>().TakeDamage(explosionDamage);
        }
    }
    IEnumerator TimeToGrow()
    {
        yield return new WaitForSeconds(explosionGrowTime);
        growing = false;
    }
    IEnumerator TimeToShrink()
    {
        yield return new WaitForSeconds(explosionShrinkTime);
        Destroy(gameObject);
    }
}
