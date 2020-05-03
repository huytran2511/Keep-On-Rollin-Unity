using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PauseMenu : MonoBehaviour
{
    public static bool gamePaused = false;
    private TMP_Text highscore_PMText;
    public GameObject pauseMenuUI;

    void Awake()
    {
        highscore_PMText = GameObject.Find("HighScore_PM").GetComponent<TMP_Text>();
        pauseMenuUI.SetActive(false);
    }

    void Update()
    {
        //if (!PlatformCollector.gameOver && !Player.finish)
        //{
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (gamePaused)
                {
                    Resume();
                }
                else
                {
                    Pause();
                }
            }
        //}
        //highscore_PMText.text = "High Score: " + Player.highscore.ToString();
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        gamePaused = false;
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        gamePaused = true;
    }

    public void Restart()
    {
        gamePaused = false;
        Time.timeScale = 1f;
        //Player.score = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void GoHome()
    {
        gamePaused = false;
        Time.timeScale = 1f;
        //Player.score = 0;
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitGame()
    {
        Debug.Log("QUIT");
        Application.Quit();
    }
}
