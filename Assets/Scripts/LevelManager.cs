using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public Checkpoint activeCheckpoint;
    private PlayerController player;

    void Start()
    {
        player = FindObjectOfType<PlayerController>(); 
    }

    void Update()
    {
        
    }

    public void RespawnPlayer()
    {
        activeCheckpoint.SetRespawningState();
        player.transform.position = activeCheckpoint.transform.position;
    }
}
