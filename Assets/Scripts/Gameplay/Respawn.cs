using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    [SerializeField] private Rigidbody player;
    [SerializeField] private Transform respawnPoint;
    
    void OnCollisionEnter(Collision collision)
    {
        Invoke("RespawnPlayer", 2f);
    }

    void RespawnPlayer()
    {
        player.transform.position = respawnPoint.transform.position;
        PlayerController.gameStarted = true;
    }
}
