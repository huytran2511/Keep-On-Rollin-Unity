using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    public float speed;

    private Vector3 rotation;
    
    void Start()
    {
        rotation = new Vector3(45, 15, 90);
    }

    void Update()
    {
        this.transform.Rotate(rotation * speed * Time.deltaTime);
    }
}
