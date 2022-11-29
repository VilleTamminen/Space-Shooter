using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealBoost : MonoBehaviour
{
    public int healingAmount = 400;
    public float moveSpeed = 10;

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Player") //heals certain amount of player's health
        {
            HealthbarScript.health += healingAmount;           
            Destroy(gameObject);
        }
    }
    private void Update()
    {
        Vector3 pos = transform.position;

        var move = new Vector3(-1, 0, 0); //moves left
        transform.position += move * moveSpeed * Time.deltaTime;
    }

}
