using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiTargetRocketGhostTrail : MonoBehaviour
{
    SpriteRenderer sprite;
    public float ghostTimer = 0.2f;

    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        sprite.color = new Vector4(50, 50, 50, ghostTimer);   //this makes ghost more transparent
}

    // Update is called once per frame
    void Update()
    {        
        ghostTimer -= Time.deltaTime;

        if (ghostTimer <= 0)
        {
            Destroy(gameObject);
        }
    }
}
