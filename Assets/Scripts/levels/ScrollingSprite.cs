using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingSprite : MonoBehaviour
{
    //place this script to quad object. change standard material to > unlit > texture.
    Material material;
    Vector2 offset;
    public float xVelocity, yVelocity;

    void Start()
    {
        material = GetComponent<Renderer>().material;  //get access to renderer's material
        offset = new Vector2(xVelocity, yVelocity);   
    }

    void Update()
    {
        material.mainTextureOffset += offset * Time.deltaTime;
    }
}
