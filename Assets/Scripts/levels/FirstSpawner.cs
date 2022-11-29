using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstSpawner : MonoBehaviour
{
    public int screenboundaryYtop = 55;   //top part of screen y axel
    public int screenboundaryYbottom = -42;   //bottom part of screen y axel

    public GameObject enemyPrefab1;  //red carp
    public GameObject enemyPrefab2;  //heavy enemy
    public GameObject enemyPrefab3;   //green seeker swarm
    public GameObject enemyPrefab4;   //bomber fire ant

    public float respawnTime = 2.0f;
    public float boostTime = 10.0f;
    public GameObject healBoost;
    public GameObject shieldBoost;
    public GameObject superBoost;
    public GameObject rocketPickUp;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(enemyWave());
        StartCoroutine(boostWave());
    }
    private void spawnEnemy()
    {
        // GameObject a = Instantiate(enemyPrefab1) as GameObject;
        // a.transform.position = new Vector2(100, Random.Range(screenboundaryYbottom, screenboundaryYtop));  //spawn position x-axel, random range y.bottom to y.top -axel
        float randomValue = Random.Range(0, 101);

        if (randomValue < 40)  //red carp
        {
            GameObject a = Instantiate(enemyPrefab1) as GameObject;
            a.transform.position = new Vector2(130, Random.Range(screenboundaryYbottom, screenboundaryYtop));
            GameObject aa = Instantiate(enemyPrefab1) as GameObject;
            aa.transform.position = new Vector2(130, Random.Range(screenboundaryYbottom, screenboundaryYtop));
            GameObject ab = Instantiate(enemyPrefab1) as GameObject;
            ab.transform.position = new Vector2(130, Random.Range(screenboundaryYbottom, screenboundaryYtop));
            GameObject ac = Instantiate(enemyPrefab1) as GameObject;
            ac.transform.position = new Vector2(130, Random.Range(screenboundaryYbottom, screenboundaryYtop));
        }
        if (randomValue >= 40 && randomValue < 60) //heavy enemy
        {
            GameObject b = Instantiate(enemyPrefab2) as GameObject;
            b.transform.position = new Vector2(130, Random.Range(screenboundaryYbottom, screenboundaryYtop));
        }
        if (randomValue >= 60 && randomValue < 80) //green seeker swarm
        {
            GameObject c = Instantiate(enemyPrefab3) as GameObject;
            c.transform.position = new Vector2(130, Random.Range(screenboundaryYbottom, screenboundaryYtop));
        }
        if (randomValue >= 80) //bomber fire ant
        {
            GameObject d = Instantiate(enemyPrefab4) as GameObject;
            d.transform.position = new Vector2(130, Random.Range(screenboundaryYbottom, screenboundaryYtop));
        }
    }
    IEnumerator enemyWave()
    {
        while (true){
            yield return new WaitForSeconds(respawnTime);  //waittime between enemyWave spawns
            spawnEnemy();
        }
    }
    private void spawnBoost()
    {        
        switch (Random.Range(0, 5))  //equal chances here
        {
            case 0:
                GameObject boostOne = Instantiate(healBoost) as GameObject;
                boostOne.transform.position = new Vector2(130, Random.Range(screenboundaryYbottom, screenboundaryYtop));
                break;
            case 1:
                GameObject boostTwo = Instantiate(shieldBoost) as GameObject;
                boostTwo.transform.position = new Vector2(130, Random.Range(screenboundaryYbottom, screenboundaryYtop));
                break;
            case 2:
                GameObject boostThree = Instantiate(superBoost) as GameObject;
                boostThree.transform.position = new Vector2(130, Random.Range(screenboundaryYbottom, screenboundaryYtop));
                break;
            case 3:
                GameObject boostFour = Instantiate(rocketPickUp) as GameObject;
                boostFour.transform.position = new Vector2(130, Random.Range(screenboundaryYbottom, screenboundaryYtop));  
                break;

        }
    }
    IEnumerator boostWave() //spawn random boost
    {
        while (true)
        {
            yield return new WaitForSeconds(boostTime);
            spawnBoost();
        }
    }
}
