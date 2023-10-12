using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public bool enabledLevel1 = true;
    public bool enabledLevel2 = false;
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
        player = FindObjectOfType<PlayerController>();
        activeCheckpoint.SetRespawningState();
        player.transform.position = activeCheckpoint.transform.position;
    }
}
