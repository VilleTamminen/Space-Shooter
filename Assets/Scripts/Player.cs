using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour  //rigidbody that moves and stops on walls/boundaries, but detects enemy collision by using trigger, OnTriggerEnter().
{
    //player has no own health. player dies if healthBarScript goes to zero. health is 1000
    //public Player player;  //not necessary
    public Rigidbody2D rb;
    public float speed = 30f;

    float damageInsideEnemy = 3.0f;         //damage to player upon touch to enemy 
    public static bool invincible = false;  //player is invincible if gets pick up boost = no damage taken. public static for Superboost script.
    public static float boostTimer = 10f;   //time invincibility lasts. changing it doesn't update other code lines of it. must do it manually on all lines.
    float invincibleDamage = 10f;

    public static float shield = 0;  //amount of shield boost the player is carrying
    public GameObject ShieldExplosion;
    //shield's max amount is declared in ShieldFill script. it is 8.

    //fire type 1: bullets
    public float fireRate1;
    private float nextFire1;
    public GameObject Attack1;
    public Transform Attack1Spawn;  //placed to the spot where we want the bullet to spawn

    //fire type 2: rockets
    public static int rocketAmmo = 4;       //amount of rocket ammo player currently has
    public static int maxRocketAmmo = 4;    //max ammo checkup is done in rocket pickup script
    public float fireRate2;
    private float nextFire2;
    public GameObject Attack2;
    public Transform Attack2Spawn;

    //copypasta for ghostTrail starts here
    private static Player instance;
    public SpriteRenderer playerSprite;

    [SerializeField]
    GameObject PlayerGhostTrail;

    public static Player Instance  //instance for ghost trail
    {
        get
        {
            if (instance == null)
            {
                instance = GameObject.FindObjectOfType<Player>();
            }
            return instance;
        }
    } //copypasta for ghosTrail ends here, but there are another lines.

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerSprite = GetComponent<SpriteRenderer>();  //player ghostTrail stuff

        shield = 0;   //zero shields at start
    }
    void Move()
    {
        //Move player ship
        Vector3 pos = transform.position;

        var move = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);  //move is first time introduced here
        transform.position += move * speed * Time.deltaTime;

        if (invincible == true)
        {
            GameObject GhostTrailBaby = Instantiate(PlayerGhostTrail, transform.position, transform.rotation);  //creates ghostTrailBaby for ghostTrail
        }      
    }
    void Shoot()
    {
        //fire normal bullets, left mouse hold
        if (Input.GetButton("Fire1") && Time.time > nextFire1)
        {
            nextFire1 = Time.time + fireRate1;
            Instantiate(Attack1, Attack1Spawn.position, Attack1Spawn.rotation);
        }
        //rockets, right mouse click
        if (Input.GetButton("Fire2") && Time.time > nextFire2 && rocketAmmo > 0)
        {
            if (GameObject.FindWithTag("Enemy") != null) //if enemy exist, rocket can be fired. This is to prevent aimless enemy seaching.
            {
                nextFire2 = Time.time + fireRate2;
                Instantiate(Attack2, Attack2Spawn.position, Attack2Spawn.rotation);
                rocketAmmo--;
            }
        }
    }
    void Status()
    {
        //super boost
        if (invincible == false)
        {
            boostTimer = 10;
        }
        if (invincible == true) //won't take damage for short time
        {
            boostTimer -= Time.deltaTime;
            if (boostTimer <= 0)
            {
                invincible = false;
                boostTimer = 10f;
            }
        }
    }

    void Update()
    {
        Move();
        Shoot();
        Status();
    }

    void OnTriggerStay2D(Collider2D collider)
    {
        //enemy projectile detection/damage is not done here. it is in EnemyProjectile script.
        if (collider.tag == "Enemy" && invincible == false && shield == 0)  //player takes damage over time if inside enemy
        {
            HealthbarScript.health -= damageInsideEnemy;
        }
        if (collider.tag == "Enemy" && invincible == false && shield > 0)  //no damage if player has shields during collision
        {
            Instantiate(ShieldExplosion, transform.position, transform.rotation);  //create ONE explosion. Still needs a way to increase damage by shield amount
            shield = 0; // lose all shields
            //collision doens't detect Enemyprojectiles(they use forces)
        }
        if (collider.tag == "Enemy" && invincible == true)  //enemy takes small damage from invincible player
        {
            collider.GetComponent<EnemyCollider>().TakeDamage(invincibleDamage);
        }
    }
}
