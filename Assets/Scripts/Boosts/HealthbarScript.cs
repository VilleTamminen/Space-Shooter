using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthbarScript : MonoBehaviour
{
    Image healthbar;
    float maxHealth = 1000;
    public static float health;

    // Start is called before the first frame update
    void Start()
    {
        healthbar = GetComponent<Image>();
        health = maxHealth;
    }
    public void Heal(int healing)
    {
        health += healing;      
    }

    // Update is called once per frame
    void Update()
    {
        if (health > maxHealth) //health cannot be bigger than max health
        {
            health = maxHealth;
        }
        if(health < 0) //health cannot be negative
        {
            health = 0;
        }
        healthbar.fillAmount = health / maxHealth;
        double colorGreen = (health - maxHealth) / 10 * (-5.1);  //green must change from 0 to 255
        double colorRed = health * 0.51;  // red must change from 255 to 0 

        //Change healthbar color 
        if (health > maxHealth / 2) //color goes from green to yellow when health over 50%
        {
            healthbar.GetComponent<Image>().color = new Color32((byte)(colorGreen), 255, 0, 255); 
        }
        if (health < maxHealth / 2) //color goes from yellow to red when health less than 50% 
        {
            healthbar.GetComponent<Image>().color = new Color32(255, (byte)(colorRed), 0, 255); 
        }
    }   
}
