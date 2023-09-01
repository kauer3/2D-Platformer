using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPlayer : MonoBehaviour
{
    public LevelManager levelManager;
    public AudioSource deathSound;

    void Start()
    {
        levelManager = FindObjectOfType<LevelManager>(); 
        deathSound = GetComponent<AudioSource>();
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
       if(other.name == "Player")
        {
            levelManager.RespawnPlayer();
            deathSound.Play();
        }
    }
}
