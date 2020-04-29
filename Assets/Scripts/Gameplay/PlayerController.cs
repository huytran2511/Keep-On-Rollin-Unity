using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Threading;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public TMP_Text scoreText;
    
    private Rigidbody player;
    private int score;
    private GameObject[] gems;
    private Vector3 startPosition;

    void Start()
    {
        player = GetComponent<Rigidbody>();
        gems = GameObject.FindGameObjectsWithTag("Gem");
        startPosition = player.position;
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
        else if (collider.gameObject.CompareTag("Win"))
        {
            ResetGameState();
        }
        else if (collider.gameObject.CompareTag("GameOver"))
        {
            ResetGameState();
        }

    }
    void UpdateScoreText()
    {
        scoreText.text = "Score: " + score;
    }

    void ResetGameState()
    {
        score = 0;
        UpdateScoreText();

        // for each gem, set active flag back to true
        foreach(GameObject gem in gems)
        {
            gem.SetActive(true);
        }

        // set player position and velocity to start
        player.position = startPosition;
        player.velocity = Vector3.zero;
        player.angularVelocity = Vector3.zero;
    }
}
