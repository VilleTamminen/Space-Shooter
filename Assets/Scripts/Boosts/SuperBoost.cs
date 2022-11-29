using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperBoost : MonoBehaviour
{
    public float moveSpeed = 10;

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Player") //activates invincibility
        {
            Player.invincible = true;
            Player.boostTimer = 10;
            Destroy(gameObject);
        }
    }
    
    private void Update()
    {
        
            Vector3 pos = transform.position;

            var move = new Vector3(-1, 0, 0);
            transform.position += move * moveSpeed * Time.deltaTime;
    }
}
