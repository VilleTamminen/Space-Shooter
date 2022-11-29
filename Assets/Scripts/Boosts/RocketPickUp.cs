using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketPickUp : MonoBehaviour
{
    public float moveSpeed = 10;

    void OnTriggerStay2D(Collider2D collider)
    {
        if (collider.tag == "Player") 
        {
            if (Player.rocketAmmo < Player.maxRocketAmmo) //if player doesn't have max ammo, pick rocket ammo up
            {
                Player.rocketAmmo++;
                Destroy(gameObject);
            }
        }
    }
    private void Update()
    {
        Vector3 pos = transform.position;

        var move = new Vector3(-1, 0, 0);
        transform.position += move * moveSpeed * Time.deltaTime;
    }
}
