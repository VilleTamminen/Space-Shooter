using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollider : MonoBehaviour
{
    public float health = 250;
    float maxHealth;
    public bool hasAnimator = false;
    public Animator animator;
    SpriteRenderer sprite;
    public bool lowHealthEvent = false;

    void Start()
    {
        if (hasAnimator == true)
        {
            animator.enabled = false;      //stops animator from starting early
        }
        maxHealth = health;
        sprite = GetComponent<SpriteRenderer>();
    }
    public void TakeDamage(float damage)  //previously int
    {
        health -= damage;
    }
    void Update()
    {
        if(health <= 0)   //destroy when 0 health
        {
            sprite.GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 255); //change color back to normal
            Destroy(GetComponent<PolygonCollider2D>());  //no collider = no damage to player after enemy death during animation
            animator.enabled = true;
            transform.gameObject.tag = "Untagged";   //stops rocket from homing to after explosion of enemy
            StartCoroutine(Death()); //start Death process

            foreach (Transform child in transform)  //destroy existing children of this object
            {
                GameObject.Destroy(child.gameObject);
            }
        }
        if (health <= 0 && hasAnimator == false) //just destroy
        {
            Destroy(gameObject);
        }
        if(health <= health / 5) //low health check for bomber fire ant's explosion
        {
            lowHealthEvent = true;
        }

        if (health > 0)
        {
            //change color to red based on health. 
            float red = 255 / maxHealth * health;
            sprite.GetComponent<SpriteRenderer>().color = new Color32(255, (byte)(red), (byte)(red), 255);
        }        
    }
    IEnumerator Death()
    {
        yield return new WaitForSeconds(3);  //wait 3 seconds and then destroys itself        
        Destroy(gameObject);
    }  

}
