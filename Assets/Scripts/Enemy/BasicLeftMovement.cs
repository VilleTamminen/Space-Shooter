using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicLeftMovement : MonoBehaviour
{
    public float moveSpeed = 10;
    Rigidbody2D rb;

    void MoveLeft()
    {
        Vector3 pos = transform.position;

        var move = new Vector3(-1, 0, 0);
        transform.position += move * moveSpeed * Time.deltaTime;
    }
    void Update()
    {              
            MoveLeft();
    }
}
