using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public LevelManager levelManager;
    public AudioSource checkpointSound;
    public bool respawning;

    void Start()
    {
        levelManager = FindObjectOfType<LevelManager>();
        checkpointSound = GetComponent<AudioSource>();
    }

    void Update()
    {
        
    }

    public void SetRespawningState()
    {
        respawning = true;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Player")
        {
            if (respawning)
            {
                respawning = false;
            }
            else
            {
                levelManager.activeCheckpoint = this;
                checkpointSound.Play();
            }
        }
    }
}
