using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RocketFill : MonoBehaviour
{
    Image rocketBar;
    float maxAmmo = 4f;  //has to be float for fillAmount

    void Start()
    {
        rocketBar = GetComponent<Image>();
        rocketBar.enabled = true;
    }

    void Update()
    {
        float ammo = Player.rocketAmmo;

        if (ammo > 0)
        {
            rocketBar.fillAmount = 1.0f / maxAmmo * ammo;  //fillAmount has to be float to work
        }
        if(ammo == 0)
        {
            rocketBar.fillAmount = 0.01f;    //bad things might happen if reach 0
        }
    }
}
