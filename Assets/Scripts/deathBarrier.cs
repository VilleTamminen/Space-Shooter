using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deathBarrier : MonoBehaviour
{
    int lastBarrier = -160;
    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < lastBarrier)  //destroy this gameobject if x position is less than lastBarrier
        {
            Destroy(gameObject);
        }
    }
}
