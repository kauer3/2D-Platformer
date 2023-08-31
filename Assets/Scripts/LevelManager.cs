using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public GameObject activeCheckpoint;
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
        player.transform.position = activeCheckpoint.transform.position;
    }
}
