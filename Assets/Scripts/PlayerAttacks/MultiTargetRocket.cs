using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;   //for closest target finding

public class MultiTargetRocket : MonoBehaviour
{
    //this missile homes into enemies, tutorial from Brackeys and internet. altered by myself to lock into multiple targets.
    private Transform target;
    private Rigidbody2D rb;
    private CircleCollider2D circle;
    public float speed = 25f;
    public float rotateSpeed = 200f;
    private float rocketDamage = 300;  //previously int
    private float explosionTriggerDistance = 5f;
    private float rocketTimeToLive = 15f;  //how long rocket can exist max

    [SerializeField]
    GameObject RocketGhostTrail;
    [SerializeField]
    GameObject RocketExplosion;
    //Instance was deleted, since it was not needed for ghost after all

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        target = GameObject.FindWithTag("Enemy").transform;  //target is sadly the latest spawned enemy

        //find closest target
        // target = GameObject.FindGameObjectsWithTag("Enemy").Aggregate((o1, o2) => Vector3.Distance(o1.transform.position, this.transform.position) > Vector3.Distance(o2.transform.position, this.transform.position) ? o2 : o1).transform;
        //ScanForEnemies();
        StartCoroutine(RocketLifeSpan());
    }

    void FixedUpdate() //fixedUpdate for physics. Creates ghostTrail(succesful) and finds targets. Target findng may create error if no targets exist.
    {
         GameObject GhostTrailBaby = Instantiate(RocketGhostTrail, transform.position, transform.rotation);  //creates ghostTrailBaby for ghostTrail. It may be wise to limit the amount that can be spawned at the same time!!!.

        if (target != null && target.tag == "Enemy")
        {
            Vector2 direction = (Vector2)target.position - rb.position;
            direction.Normalize();
            float rotateAmount = Vector3.Cross(direction, transform.up).z;
            rb.angularVelocity = -rotateAmount * rotateSpeed;
            rb.velocity = transform.up * speed;

            if (((Vector2)target.position - rb.position).magnitude <= explosionTriggerDistance) //if distance between rocket and target is less than explosionTriggerDistance, then Boom
            {
                if (target.tag == "Enemy") //final check if target is alive and tagged
                {
                    Hit();
                }
                else
                {
                    target = GameObject.FindWithTag("Enemy").transform;  //find new target
                   // ScanForEnemies();
                }
            }
        }
        else if(target != null && target.tag == "Untagged")
        {
            target = null;
            target = GameObject.FindWithTag("Enemy").transform;  //find new target, causes error if no more targets exist :(
           // ScanForEnemies();
            if (target.tag != "Enemy" || target == null)
            {
                SelfBoom();
            }           
        }
        else
        {
            SelfBoom(); //destroy rocket if no enemies found. Prevent aimless enemy searching
        }
    }
    void ScanForEnemies()  //might be best if not used. if enemies don't exist it WILL cause error and either the error is No elements found or Nullreferenceexception.
    {
        //finds closest target with system.Linq
        target = GameObject.FindGameObjectsWithTag("Enemy").Aggregate((o1, o2) => Vector3.Distance(o1.transform.position, this.transform.position) > Vector3.Distance(o2.transform.position, this.transform.position) ? o2 : o1).transform;
    }
    
    void OnTriggerStay2D(Collider2D collider)
    {
        if (collider.tag == "Enemy")
        {
            target = collider.transform;  //new target is the one inside circle collider
        }
    }
    void OnCollisionEnter2D() //direct collision with enemy on polygon collider
    {
            Hit();       
    }
    void Hit() //damage the enemy
    {
        target.GetComponent<EnemyCollider>().TakeDamage(rocketDamage);  //damage to enemy. If no targets exist, this won't work and causes errors
        Instantiate(RocketExplosion, transform.position, transform.rotation);  //create explosion field
        Destroy(gameObject);
    }
    void SelfBoom()  //skips direct damage to enemy that doesn't exist
    {
        Instantiate(RocketExplosion, transform.position, transform.rotation);  //create explosion field
        Destroy(gameObject);
    }
    IEnumerator RocketLifeSpan()  //rocket won't linger in space for too long
    {
        while (true)
        {
            yield return new WaitForSeconds(rocketTimeToLive);
            SelfBoom();
        }
    }
}

