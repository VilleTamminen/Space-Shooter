using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectLevel : MonoBehaviour
{
    public string sceneName;

    void OnTriggerStay2D(Collider2D collider)
    {
        if (collider.tag == "Player" && Input.GetKeyDown("return"))  //return button is enter on keyboard
        {
            SceneManager.LoadScene(sceneName, LoadSceneMode.Single);  //load the named scene.
        }

    }
}
