using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    public static Vector3 offset, originalCameraPos;

    void Start()
    {
        originalCameraPos = new Vector3(player.transform.position.x, player.transform.position.y + 0.8f, player.transform.position.z - 5.0f);
        offset = originalCameraPos;
    }

    void FixedUpdate()
    {
        if (PlayerController.gameStarted)
        {
            offset = Quaternion.AngleAxis(Input.GetAxis("Horizontal") * 300.0f * Time.deltaTime, Vector3.up) * offset;
            transform.position = player.transform.position + offset;
            transform.LookAt(player.transform.position);
        }

    }
}
