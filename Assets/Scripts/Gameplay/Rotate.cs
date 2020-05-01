using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    private float speed = 1.0f;

    private Vector3 gemRotation, starRotation;
    
    void Start()
    {
        gemRotation = new Vector3(45, 15, 90);
        starRotation = new Vector3(0, 100, 0);
    }

    void Update()
    {
        if (gameObject.CompareTag("Gem"))
        {
            this.transform.Rotate(gemRotation * speed * Time.deltaTime);
        }
        else if (gameObject.CompareTag("Star"))
        {
            this.transform.Rotate(starRotation * speed * 2 * Time.deltaTime);
        }
    }
}
