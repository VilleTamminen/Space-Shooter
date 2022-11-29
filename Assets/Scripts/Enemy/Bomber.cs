using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomber : MonoBehaviour
{
    [SerializeField]
    GameObject HarmfulExplosion;  //explosion harms everyone  

    void Update()
    {
        if (GetComponent<EnemyCollider>().lowHealthEvent == true) //if object has low health, self detonate
        {
            Instantiate(HarmfulExplosion, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
