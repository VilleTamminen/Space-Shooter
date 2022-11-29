using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySeeker : MonoBehaviour
{
    //for seeking, not damaging
    private Transform target;
    private Rigidbody2D rb;
    public float speed = 30f;
    public float rotateSpeed = 200f;
    public float timeTillDeath = 20f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        target = GameObject.FindWithTag("Player").transform;  //find the player and set as target
        StartCoroutine(TimeToLive());
    }

    void FixedUpdate() //fixedUpdate for physics.
    {
        //basic movement
        Vector2 direction = (Vector2)target.position - rb.position;
        direction.Normalize();
        float rotateAmount = Vector3.Cross(direction, transform.up).z;
        rb.angularVelocity = -rotateAmount * rotateSpeed;
        rb.velocity = transform.up * speed;
    }
    IEnumerator TimeToLive()
    {
        yield return new WaitForSeconds(timeTillDeath);  //wait sometime before death. we don't want these to stay alive too long
        Destroy(gameObject);
    }

}
