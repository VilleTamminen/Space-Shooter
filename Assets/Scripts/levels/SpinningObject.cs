﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinningObject : MonoBehaviour
{
    float speed = 8f;

    void Update()
    {
        transform.Rotate(-Vector3.forward * speed * Time.deltaTime);
    }
}
