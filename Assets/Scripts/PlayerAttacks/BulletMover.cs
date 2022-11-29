using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMover : MonoBehaviour
{
    public float speed;
    float damage = 100;

    void Update()
    {
        transform.Translate(speed * Time.deltaTime, 0, 0);
    }
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Enemy")  //if bullet hits enemy, deliver damage and destroy bullet
        {
            collider.GetComponent<EnemyCollider>().TakeDamage(damage);  //all enemies must have EnemyCollider or EnemySeeker
            Destroy(gameObject);
        }
        if (collider.tag != "Player" && collider.tag != "Boost" && collider.tag != "PlayerAttack2" && collider.tag != "EnemyProjectile" && collider.tag != "Harmless") //if bullet hits something else than player or boost or enemyprojectile, destroy bullet
        {
            Destroy(gameObject);
        }
    }
}
