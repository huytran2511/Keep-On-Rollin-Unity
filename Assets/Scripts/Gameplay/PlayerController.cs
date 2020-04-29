using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class PlayerController : MonoBehaviour
{
    public float speed;
    public TMP_Text scoreText;
    
    private Rigidbody player;
    private int score;

    void Start()
    {
        player = GetComponent<Rigidbody>();
        score = 0;
        UpdateScoreText();
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        player.AddForce(movement * speed * Time.deltaTime);
    }

    void OnTriggerEnter(Collider collider)
    {
        // check if the collider is of tag 'gem'
        if (collider.gameObject.CompareTag("Gem"))
        {
            collider.gameObject.SetActive(false);
            score++;
            UpdateScoreText();
        }
    }

    void UpdateScoreText()
    {
        scoreText.text = "Score: " + score;
    }
}
