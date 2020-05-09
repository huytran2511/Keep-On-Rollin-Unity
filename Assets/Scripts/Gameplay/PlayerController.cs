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

    //public GameObject starEmpty1, starEmpty2, starEmpty3;
    //public GameObject starFull1, starFull2, starFull3;
    //public GameObject starEmptyWin1, starEmptyWin2, starEmptyWin3;
    //public GameObject starFullWin1, starFullWin2, starFullWin3;

    public GameObject[] starEmpty, starFull, starEmptyWin, starFullWin;

    public static bool gameStarted, winLv1 = false, winLv2 = false;

    public AudioSource[] sounds;
    private AudioSource gemSound, starSound, splashSound, winSound, loseSound;

    private float startTime, timeLeft;
    private float speed = 1000f;

    private Rigidbody player;
    private int gemScore, starScore;
    private GameObject[] gems, stars;
    private Vector3 startPos;
    //private bool gameStarted;

    void Start()
    {
        Time.timeScale = 1f;
        //gameStarted = true;
        player = GetComponent<Rigidbody>();
        startPos = player.position;

        sounds = GetComponents<AudioSource>();
        gemSound = sounds[0];
        starSound = sounds[1];
        splashSound = sounds[2];
        winSound = sounds[3];
        loseSound = sounds[4];

        if(SceneManager.GetActiveScene().name == "Lv1")
        {
            startTime = 60f;
        }
        if (SceneManager.GetActiveScene().name == "Lv2")
        {
            startTime = 60f;
        }
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



    //void Update()
    //{
    //    timeLeft -= Time.deltaTime;
    //    if (timeLeft <= startTime)
    //    {
    //        timer.text = "TIME\n" + timeLeft.ToString("F2");
    //    }
    //    if (timeLeft < 0)
    //    {
    //        LoseGame();
    //    }
    //}

    void FixedUpdate()
    {
        if (gameStarted)
        {
            float moveVertical = Input.GetAxis("Vertical");
            float moveHorizontal = Input.GetAxis("Horizontal");
            float rotateVelocity = 410f;
            Vector3 movement = Camera.main.transform.forward * moveVertical;

            player.angularDrag = 1f;
            player.AddForce(movement * speed * Time.deltaTime);
            player.velocity = Quaternion.Euler(0f, moveHorizontal * rotateVelocity * Time.deltaTime, 0f) * player.velocity;
        }

        timeLeft -= Time.deltaTime;
        if (timeLeft <= startTime)
        {
            timer.text = "TIME\n" + timeLeft.ToString("F2");
        }
        if (timeLeft < 0)
        {
            LoseGame();
        }

        if (gemScore == 10)
        {
            WinGame();
        }
        DisplayStar();
    }

    IEnumerator Countdown(int seconds)
    {
        int count = seconds;
        while (count > 0)
        {
            if (count < 5 && count > 1)
            {
                startCountdown.text = (count - 1).ToString();
                sounds[count + 3].Play();
            }
            if(count == 1)
            {
                startCountdown.text = "GO!";
                sounds[8].Play();
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
        if (collider.gameObject.CompareTag("Sea"))
        {
            splashSound.Play();
        }
    }

    void WinGame()
    {
        winSound.Play();
        gameStarted = false;
        winLv1 = true;
        if(starScore > LevelsMenu.starScore)
        {
            LevelsMenu.starScore = starScore;
        }   
        //ResetGameState();
        winUI.SetActive(true);

        HUD.SetActive(false);
        Time.timeScale = 0f;
    }

    void LoseGame()
    {
        //splashSound.Play();
        loseSound.Play();
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
        if (collision.gameObject.CompareTag("Respawn"))
        {
            player.velocity = Vector3.zero;
            player.angularVelocity = Vector3.zero;
            gameStarted = false;
            //splashSound.Play();
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
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void DisplayStar()
    {
        if (starScore == 0)
        {
            starEmpty[0].SetActive(true);
            starEmpty[1].SetActive(true);
            starEmpty[2].SetActive(true);
            starFull[0].SetActive(false);
            starFull[1].SetActive(false);
            starFull[2].SetActive(false);

            starEmptyWin[0].SetActive(true);
            starEmptyWin[1].SetActive(true);
            starEmptyWin[2].SetActive(true);
            starFullWin[0].SetActive(false);
            starFullWin[1].SetActive(false);
            starFullWin[2].SetActive(false);
        }
        if (starScore == 1)
        {
            starEmpty[0].SetActive(false);
            starEmpty[1].SetActive(true);
            starEmpty[2].SetActive(true);
            starFull[0].SetActive(true);
            starFull[1].SetActive(false);
            starFull[2].SetActive(false);

            starEmptyWin[0].SetActive(false);
            starEmptyWin[1].SetActive(true);
            starEmptyWin[2].SetActive(true);
            starFullWin[0].SetActive(true);
            starFullWin[1].SetActive(false);
            starFullWin[2].SetActive(false);
        }
        if (starScore == 2)
        {
            starEmpty[0].SetActive(false);
            starEmpty[1].SetActive(false);
            starEmpty[2].SetActive(true);
            starFull[0].SetActive(true);
            starFull[1].SetActive(true);
            starFull[2].SetActive(false);

            starEmptyWin[0].SetActive(false);
            starEmptyWin[1].SetActive(false);
            starEmptyWin[2].SetActive(true);
            starFullWin[0].SetActive(true);
            starFullWin[1].SetActive(true);
            starFullWin[2].SetActive(false);
        }
        if (starScore == 3)
        {
            starEmpty[0].SetActive(false);
            starEmpty[1].SetActive(false);
            starEmpty[2].SetActive(false);
            starFull[0].SetActive(true);
            starFull[1].SetActive(true);
            starFull[2].SetActive(true);

            starEmptyWin[0].SetActive(false);
            starEmptyWin[1].SetActive(false);
            starEmptyWin[2].SetActive(false);
            starFullWin[0].SetActive(true);
            starFullWin[1].SetActive(true);
            starFullWin[2].SetActive(true);
        }
    }
}
