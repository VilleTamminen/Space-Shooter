using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShieldFill : MonoBehaviour
{
    Image shieldFill;
    float shieldMaxAmount = 8f;  //8 shields is max amount. it has to be float for fillAmount.

    void Start()
    {
        shieldFill = GetComponent<Image>();
        shieldFill.enabled = true;
    }

    void Update()
    {
        float shieldAmount = Player.shield;  //copy how many shields player has

        if (shieldAmount > 0 && shieldAmount <= 8)
        {
            shieldFill.fillAmount = 1.0f / shieldMaxAmount * shieldAmount;  //fillAmount has to be float to work
            shieldFill.fillAmount = 1.0f / 8 * shieldAmount; //fillAmount has to be float to work
        }
        if (shieldAmount == 0)
        {
            shieldFill.fillAmount = 0.01f;    //bad things might happen if reach 0
        }
    }
}
