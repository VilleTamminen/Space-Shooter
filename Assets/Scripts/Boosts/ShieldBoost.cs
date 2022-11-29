using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldBoost : MonoBehaviour
{
    public float moveSpeed = 10;

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Player" && Player.shield < 8) //give player plus one shield
        {
            Player.shield++;
            Destroy(gameObject);
        }
    }
    void Update()  //move left
    {
        Vector3 pos = transform.position;

        var move = new Vector3(-1, 0, 0);
        transform.position += move * moveSpeed * Time.deltaTime;

    }
}
