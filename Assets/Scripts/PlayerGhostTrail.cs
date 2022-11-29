using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGhostTrail : MonoBehaviour
{
    SpriteRenderer sprite;
    float ghostTimer = 0.2f;

    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();

        //unnecessary code here
        //transform.position = Player.Instance.transform.position;
       // transform.localScale = Player.Instance.transform.localScale;
        //sprite.sprite = Player.Instance.playerSprite.sprite;  //this line uses the player's sprite. we don't want that. we want a nice glow effect!
        //sprite.color = new Vector4(50, 50, 50, ghostTimer);   //this makes ghost more transparent
    }

    // Update is called once per frame
    void Update()
    {
        ghostTimer -= Time.deltaTime;
        
        if(ghostTimer <= 0)
        {
            Destroy(gameObject);
        }
    }
}
