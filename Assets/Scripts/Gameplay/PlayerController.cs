using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Threading;
using UnityEngine.UI;
using System;

public class PlayerController : MonoBehaviour
{
    
    public TMP_Text gemText, starText, winText, timer;
    //public Button restartButton;

    public GameObject gameOverUI, winUI, HUD;

    public float startTime;
    
    public AudioSource[] sounds;
    private AudioSource gemSound, starSound, splashSound, winSound;

    private float timeLeft;
    private float speed = 1000.0f;
    private Rigidbody player;
    private int gemScore, starScore;
    private GameObject[] gems, stars;
    private Vector3 startPosition;
    private bool gameStarted;


    void Start()
    {
        player = GetComponent<Rigidbody>();
        sounds = GetComponents<AudioSource>();
        gemSound = sounds[0];
        starSound = sounds[1];
        splashSound = sounds[2];
        winSound = sounds[3];

        timeLeft = startTime;

        gems = GameObject.FindGameObjectsWithTag("Gem");
        stars = GameObject.FindGameObjectsWithTag("Star");
        startPosition = player.position;
        //restartButton.onClick.AddListener(PlayAgain);
        gameStarted = true;
        gemScore = 0;
        starScore = 0;
        UpdateScoreText();
    }

    void Update()
    {
        timeLeft -= Time.deltaTime;
        timer.text = "TIME\n" + timeLeft.ToString("F2");
        if(timeLeft < 0)
        {
            LoseGame();
        }
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
        if (gemScore == 1)
        {
            WinGame();
        }

        //need condition for when collect all stars
        
    }

    void OnTriggerEnter(Collider collider)
    {
        // check if the collider is of tag 'gem'
        if (collider.gameObject.CompareTag("Gem"))
        {
            collider.gameObject.SetActive(false);
            gemSound.Play();
            gemScore++;
            UpdateScoreText();
        }
        if (collider.gameObject.CompareTag("Star"))
        {
            collider.gameObject.SetActive(false);
            starSound.Play();
            starScore++;
            UpdateScoreText();
        }
        if (collider.gameObject.CompareTag("GameOver"))
        {
            LoseGame();
        }
    }

    void WinGame()
    {
        winSound.Play();
        gameStarted = false;
        //ResetGameState();
        
        winText.text = "YOU WIN!!!\nStars: " + starScore + "/3";
        //winText.gameObject.SetActive(true);
        //restartButton.gameObject.SetActive(true);
        winUI.SetActive(true);

        //gemText.gameObject.SetActive(false);
        //starText.gameObject.SetActive(false);
        //timer.gameObject.SetActive(false);
        HUD.SetActive(false);
        Time.timeScale = 0f;
    }

    void LoseGame()
    {
        splashSound.Play();
        gameStarted = false;
        //ResetGameState();

        //loseText.text = "GAME OVER";
        //loseText.gameObject.SetActive(true);
        //restartButton.gameObject.SetActive(true);
        gameOverUI.SetActive(true);


        //gemText.gameObject.SetActive(false);
        //starText.gameObject.SetActive(false);
        //timer.gameObject.SetActive(false);
        HUD.SetActive(false);
        Time.timeScale = 0f;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("SpeedBoost"))
        {
            player.AddForce(player.velocity.normalized * 400.0f * Time.deltaTime, ForceMode.Impulse);
        }
    }
    void UpdateScoreText()
    {
        gemText.text = "Gems: " + gemScore + "/10";
        starText.text = "Stars " + starScore + "/3";
    }

    void ResetGameState()
    {
        // for each gem and star, set active flag back to true
        foreach(GameObject gem in gems)
        {
            gem.SetActive(true);
        }
        foreach (GameObject star in stars)
        {
            star.SetActive(true);
        }

        // set player position and velocity to start
        player.position = startPosition;
        player.velocity = Vector3.zero;
        player.angularVelocity = Vector3.zero;
        CameraController.offset = CameraController.originalCameraPos;
    }

    public void PlayAgain()
    {
        Time.timeScale = 1f;
        timeLeft = startTime;
        // reset score
        gemScore = 0;
        starScore = 0;
        UpdateScoreText();

        ResetGameState();

        // reset UI
        //gemText.gameObject.SetActive(true);
        //starText.gameObject.SetActive(true);
        //timer.gameObject.SetActive(true);
        HUD.SetActive(true);

        //loseText.gameObject.SetActive(false);
        //restartButton.gameObject.SetActive(false);
        gameOverUI.SetActive(false);
        //winText.gameObject.SetActive(false);
        winUI.SetActive(false);
        

        gameStarted = true;
    }
}
