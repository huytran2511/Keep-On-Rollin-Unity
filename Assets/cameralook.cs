using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameralook : MonoBehaviour
{
    //public GameObject player;
    //private Vector3 playerPosition;
    public Transform player;
    private Vector3 offset;

    void Start()
    {
        //offset = transform.position - player.transform.position;
        
        offset = new Vector3(player.position.x, player.position.y + 1.8f, player.position.z - 5.0f);
        //playerPosition = player.transform.position;
    }

    void FixedUpdate()
    {
        offset = Quaternion.AngleAxis(Input.GetAxis("Horizontal") * 300 * Time.deltaTime, Vector3.up) * offset;
        transform.position = player.position + offset;
        transform.LookAt(player.position);

        //transform.LookAt(player.transform);
        //transform.position = player.transform.position + offset;

        //float moveHorizontal = Input.GetAxis("Horizontal");
        //playerPosition = player.transform.position;
        //transform.RotateAround(playerPosition, Vector3.up, moveHorizontal * Time.deltaTime * 500);

        //playerbody.Rotate(Vector3.up * moveHorizontal * Time.deltaTime * 500);
    }

    //void FixedUpdate()
    //{
    //    transform.LookAt(player.transform);
    //    transform.position = player.transform.position + offset;
    //}
}
