using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Threading;
using UnityEngine.UI;
using System;

public class PlayerController : MonoBehaviour
{
    
    public TMP_Text scoreText;
    public TMP_Text loseText, winText;
    public Button restartButton;

    private float speed = 1000.0f;
    private Rigidbody player;
    private int score;
    private GameObject[] gems;
    private Vector3 startPosition;
    private bool gameStarted;

    void Start()
    {
        player = GetComponent<Rigidbody>();
        gems = GameObject.FindGameObjectsWithTag("Gem");
        startPosition = player.position;
        restartButton.onClick.AddListener(PlayAgain);
        gameStarted = true;
        score = 0;
        UpdateScoreText();
    }

    void FixedUpdate()
    {
        if (gameStarted)
        {
            float moveVertical = Input.GetAxis("Vertical");
            //float moveHorizontal = Input.GetAxis("Horizontal");

            Vector3 movement = Camera.main.transform.forward * moveVertical;
            //Vector3 movement = Camera.main.transform.forward * moveVertical + Camera.main.transform.right * moveHorizontal;

            player.AddForce(movement * speed * Time.deltaTime);

            /***OLD***/
            //float moveHorizontal = Input.GetAxis("Horizontal");
            //float moveVertical = Input.GetAxis("Vertical");

            //Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
            //player.AddForce(movement * speed * Time.deltaTime);
        }
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
            gameStarted = false;
            ResetGameState();
            winText.text = "You Win!\nFinal score: " + score;
            winText.gameObject.SetActive(true);
            restartButton.gameObject.SetActive(true);
            scoreText.gameObject.SetActive(false);
        }
        else if (collider.gameObject.CompareTag("GameOver"))
        {
            gameStarted = false;
            ResetGameState();
            loseText.text = "Game Over!\nFinal score: " + score;
            loseText.gameObject.SetActive(true);
            restartButton.gameObject.SetActive(true);
            scoreText.gameObject.SetActive(false);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("SpeedBoost"))
        {
            player.AddForce(player.velocity.normalized * 400.0f * Time.deltaTime, ForceMode.Impulse);
            Debug.Log("Speed boost");
        }
    }
    void UpdateScoreText()
    {
        scoreText.text = "Score: " + score;
    }

    void ResetGameState()
    {
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

    void PlayAgain()
    {
        // reset score
        score = 0;
        UpdateScoreText();

        // reset UI
        scoreText.gameObject.SetActive(true);
        loseText.gameObject.SetActive(false);
        winText.gameObject.SetActive(false);
        restartButton.gameObject.SetActive(false);

        gameStarted = true;
    }
}
