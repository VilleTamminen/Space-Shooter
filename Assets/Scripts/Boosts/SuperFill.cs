using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SuperFill : MonoBehaviour
{
    Image superbar;
    public Image superbarBackground;
    float boostTimer = 10f;

    void Start()
    {
        superbar = GetComponent<Image>();
        superbar.enabled = false;
        superbarBackground.enabled = false;
    }

   void Update()
    {
       if(Player.invincible == true)
        {
            superbar.enabled = true;             //show image
            superbarBackground.enabled = true;

            boostTimer = Player.boostTimer;
            superbar.fillAmount = boostTimer / 10;
            if (boostTimer <= 0.1)
            {
                superbar.enabled = false;             //hide image
                superbarBackground.enabled = false;
            }
        }     
    }
}
