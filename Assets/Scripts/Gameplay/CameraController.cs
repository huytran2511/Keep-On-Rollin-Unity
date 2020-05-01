using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    private Vector3 offset;

    /****OLD****/
    //public Transform player;

    void Start()
    {
        offset = new Vector3(player.transform.position.x, player.transform.position.y + 1.8f, player.transform.position.z - 5.0f);

        /****OLD****/
        //offset = transform.position - player.transform.position;
    }

    void FixedUpdate() //original was LateUpdate()
    {
        offset = Quaternion.AngleAxis(Input.GetAxis("Horizontal") * 300.0f * Time.deltaTime, Vector3.up) * offset;
        transform.position = player.transform.position + offset;
        transform.LookAt(player.transform.position);

        /****OLD****/
        //transform.position = player.transform.position + offset;
    }

    //void FixedUpdate()
    //{
    //    transform.LookAt(player.transform);
    //    transform.position = player.transform.position + offset;
    //}
}
