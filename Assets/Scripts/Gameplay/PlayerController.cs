using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Threading;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    
    public TMP_Text gemText, winText, timer, startCountdown;

    public GameObject gameOverUI, winUI, HUD;
    public GameObject starEmpty1, starEmpty2, starEmpty3;
    public GameObject starFull1, starFull2, starFull3;

    public GameObject starEmptyWin1, starEmptyWin2, starEmptyWin3;
    public GameObject starFullWin1, starFullWin2, starFullWin3;

    public float startTime;
    public static bool gameStarted;

    public AudioSource[] sounds;
    private AudioSource gemSound, starSound, splashSound, winSound, count1, count2, count3, countGo;

    private float timeLeft;
    private float speed = 1000.0f;
    private Rigidbody player;
    private int gemScore, starScore;
    private GameObject[] gems, stars;
    private Vector3 startPos;
    //private bool gameStarted;

    void Start()
    {
        gameStarted = true;
        player = GetComponent<Rigidbody>();
        startPos = player.position;

        sounds = GetComponents<AudioSource>();
        gemSound = sounds[0];
        starSound = sounds[1];
        splashSound = sounds[2];
        winSound = sounds[3];

        timeLeft = startTime + 5;
        timer.text = "TIME\n" + startTime.ToString("F2");
        gameStarted = false;

        gems = GameObject.FindGameObjectsWithTag("Gem");
        stars = GameObject.FindGameObjectsWithTag("Star");
        gemScore = 0;
        starScore = 0;
        UpdateScoreText();

        StartCoroutine(Countdown(6));
    }



    void Update()
    {
        timeLeft -= Time.deltaTime;
        if(timeLeft <= startTime)
        {
            timer.text = "TIME\n" + timeLeft.ToString("F2");
        }
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
            //player.velocity. = Camera.main.transform.forward;

            /***OLD***/
            //float moveHorizontal = Input.GetAxis("Horizontal");
            //float moveVertical = Input.GetAxis("Vertical");

            //Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
            //player.AddForce(movement * speed * Time.deltaTime);

            if (gemScore == 2)
            {
                WinGame();
            }
            DisplayStar();
        }
    }

    IEnumerator Countdown(int seconds)
    {
        int count = seconds;
        while (count > 0)
        {
            if (count < 5 && count > 1)
            {
                startCountdown.text = (count - 1).ToString();
                sounds[count + 2].Play();
            }
            if(count == 1)
            {
                startCountdown.text = "GO!";
                sounds[7].Play();
                gameStarted = true;
            }
            //Debug.Log(count);
            yield return new WaitForSeconds(1);
            count--;
        }
        startCountdown.gameObject.SetActive(false);
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
        winUI.SetActive(true);

        HUD.SetActive(false);
        Time.timeScale = 0f;
    }

    void LoseGame()
    {
        splashSound.Play();
        gameStarted = false;
        //ResetGameState();

        gameOverUI.SetActive(true);

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
        gemText.text = gemScore + "/10";
    }

    void ResetGameState()
    {
        // set player position and velocity to start
        player.position = startPos;
        player.velocity = Vector3.zero;
        player.angularVelocity = Vector3.zero;
        CameraController.offset = CameraController.originalCameraPos;

        // for each gem and star, set active flag back to true
        foreach (GameObject gem in gems)
        {
            gem.SetActive(true);
        }
        foreach (GameObject star in stars)
        {
            star.SetActive(true);
        }
    }

    public void PlayAgain()
    {
        //Time.timeScale = 1f;
        //ResetGameState();      
        //timeLeft = startTime;

        //// reset score
        //gemScore = 0;
        //starScore = 0;
        //UpdateScoreText();

        //// reset UI
        //HUD.SetActive(true);
        //gameOverUI.SetActive(false);
        //winUI.SetActive(false);

        //gameStarted = true;
        
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void DisplayStar()
    {
        if (starScore == 0)
        {
            starEmpty1.SetActive(true);
            starEmpty2.SetActive(true);
            starEmpty3.SetActive(true);
            starFull1.SetActive(false);
            starFull2.SetActive(false);
            starFull3.SetActive(false);

            starEmptyWin1.SetActive(true);
            starEmptyWin2.SetActive(true);
            starEmptyWin3.SetActive(true);
            starFullWin1.SetActive(false);
            starFullWin2.SetActive(false);
            starFullWin3.SetActive(false);
        }
        if (starScore == 1)
        {
            starEmpty1.SetActive(false);
            starEmpty2.SetActive(true);
            starEmpty3.SetActive(true);
            starFull1.SetActive(true);
            starFull2.SetActive(false);
            starFull3.SetActive(false);

            starEmptyWin1.SetActive(false);
            starEmptyWin2.SetActive(true);
            starEmptyWin3.SetActive(true);
            starFullWin1.SetActive(true);
            starFullWin2.SetActive(false);
            starFullWin3.SetActive(false);
        }
        if (starScore == 2)
        {
            starEmpty1.SetActive(false);
            starEmpty2.SetActive(false);
            starEmpty3.SetActive(true);
            starFull1.SetActive(true);
            starFull2.SetActive(true);
            starFull3.SetActive(false);

            starEmptyWin1.SetActive(false);
            starEmptyWin2.SetActive(false);
            starEmptyWin3.SetActive(true);
            starFullWin1.SetActive(true);
            starFullWin2.SetActive(true);
            starFullWin3.SetActive(false);
        }
        if (starScore == 3)
        {
            starEmpty1.SetActive(false);
            starEmpty2.SetActive(false);
            starEmpty3.SetActive(false);
            starFull1.SetActive(true);
            starFull2.SetActive(true);
            starFull3.SetActive(true);

            starEmptyWin1.SetActive(false);
            starEmptyWin2.SetActive(false);
            starEmptyWin3.SetActive(false);
            starFullWin1.SetActive(true);
            starFullWin2.SetActive(true);
            starFullWin3.SetActive(true);
        }
    }
}
