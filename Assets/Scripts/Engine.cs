using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;
using TMPro;
using UnityEngine.SceneManagement;
using Debug = UnityEngine.Debug;

public class Engine : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI lifesText;
    [SerializeField] TextMeshProUGUI timerText;
    public int score = 0;
    [SerializeField] int scoreToGetLife = 0;
    public int LiveAdderForScore = 0;
    public int lifes = 3;
    [SerializeField] bool gameOver = false;

    float timer;
    float seconds;
    float minutes;

    public bool isPaused = false;
    [SerializeField] GameObject pauseMenu;
    [SerializeField] GameObject gameOverMenu;

    void Start()
    {
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = score.ToString();
        if (lifes < 1)
        {
            lifesText.text = "";
        }
        else
        {
            lifesText.text = lifes.ToString();
        }
        StopWatchCalc();
        if (isPaused)
        {
            pauseMenu.SetActive(true);
            Time.timeScale = 0f;
        }
        else
        {
            pauseMenu.SetActive(false);
            Time.timeScale = 1f;
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ChangePauseState();
        }
        if (LiveAdderForScore>=scoreToGetLife)
        {
            lifes++;
            LiveAdderForScore = 0;
        }

        if (gameOver)
        {
            gameOverMenu.SetActive(true);
        }
        else
        {
            gameOverMenu.SetActive(false);
        }
        if (gameOverMenu.activeSelf)
        {
            Time.timeScale = 0f;
        }

        if (lifes < 1)
        {
            gameOver = true;
        }

    }
    void StopWatchCalc()
    {
        //if (!gameOver)
        //{
            timer += Time.deltaTime;
            seconds = (int)timer % 60;
            minutes = (int)timer / 60;
            if (seconds < 10)
            {
                timerText.text = minutes.ToString() + ":0" + seconds.ToString();
            }
            else
            {
                timerText.text = minutes.ToString() + ":" + seconds.ToString();
            }
        //}
    }

    public void ChangePauseState()
    {
        if (isPaused)
        {
            isPaused = false;
        }
        else
        {
            isPaused = true;
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene(2);
    }
}
