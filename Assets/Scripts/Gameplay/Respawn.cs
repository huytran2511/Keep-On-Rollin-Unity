using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    [SerializeField] private Rigidbody player;
    [SerializeField] private Transform respawnPoint;
    
    private void OnTriggerEnter(Collider other)
    {
        Invoke("RespawnPlayer", 1f);
        
        
    }

    void RespawnPlayer()
    {
        player.transform.position = respawnPoint.transform.position;
        player.velocity = Vector3.zero;
        player.angularVelocity = Vector3.zero;
    }
}
