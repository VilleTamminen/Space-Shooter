using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileDamage : MonoBehaviour
{
    public float projectileDamage = 60f;
    public float timeTillDeath = 20f;
    //enemy shooter uses rigidbody2D
    //projectiles don't currently have health so they can't be destroyed by player attacks

    void Start()
    {
        StartCoroutine(TimeToLive());  //make sure it dies after sometime
    }
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Player" && Player.invincible == false && Player.shield == 0)  //if projectile hits player, deliver damage and destroy projectile
        {
            HealthbarScript.health -= projectileDamage;
            Destroy(gameObject);
        }
        if (collider.tag == "Player" && Player.invincible == true)  //do not harm player that has superBoost
        {
            Destroy(gameObject);
        }
        if (collider.tag == "Player" && Player.shield > 0 && Player.invincible == false)  //do not harm player that has shields
        {
            Player.shield--;   //projectile hits on shields are not decreased on Player script. only hits from enemies decrease shields in Plaer script.
            Destroy(gameObject); 
        }
    }
    IEnumerator TimeToLive()  
    {
        while (true)
        {
            yield return new WaitForSeconds(timeTillDeath);
            Destroy(gameObject);
        }
    }
}
