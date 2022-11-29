using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    //if needed more than 1 MusicClip, make more. We need only one MusicSource
    public AudioClip MusicClip;
    public AudioSource MusicSource;

    void Start()
    {
        MusicSource.clip = MusicClip;
        MusicSource.Play();
    }
    void Update()
    {
        if (HealthbarScript.health <= 0) 
        {
            SceneManager.LoadScene("Main_Lobby", LoadSceneMode.Single);  //load the named scene. takes player back to Main_lobby
            
        }
    }
}
