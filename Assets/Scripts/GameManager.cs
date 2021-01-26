﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Text scoreText;
    [SerializeField] private Text levelText;
    [SerializeField] private GameObject chicken;
    ChickenController chickenControl;

    [SerializeField] private Button pauseButton;
    [SerializeField] private Button resumeButton;
    [SerializeField] private Button menuButton;
    [SerializeField] private Button retryButton;

    [SerializeField] private GameObject startPanel;
    [SerializeField] private GameObject gamePanel;
    [SerializeField] private GameObject pausePanel;

    [SerializeField] private GameObject pause;
    public GameObject trueIcon;
    public GameObject falseIcon;

    public static GameManager instance;
    public static bool isGameStarted = false;
    public static bool isGameEnded = false;

    public int levelNo;
    public int totalScore;
    public int score;
    

    [SerializeField] private GameObject timeBar;
    TimeBarScript timeBarScript;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);

        //PlayerPrefs.SetInt("level", 3);
        levelNo = PlayerPrefs.GetInt("level");
        totalScore = PlayerPrefs.GetInt("totalscore");

        startPanel.SetActive(true);
        gamePanel.SetActive(true);

        chickenControl = chicken.GetComponent<ChickenController>();
        timeBarScript = timeBar.GetComponent<TimeBarScript>();

        pauseButton.onClick.AddListener(Pause);
        resumeButton.onClick.AddListener(Resume);
        menuButton.onClick.AddListener(Menu);
        retryButton.onClick.AddListener(Retry);

        timeBarScript.enabled = false;
    }

    void Update()
    {
        score = chickenControl.totalScore;
        scoreText.text = "score: " + score;

        levelText.text = "level " + (levelNo + 1);

        if (Input.GetMouseButtonDown(0))
        {
            timeBarScript.enabled = true;
            startPanel.SetActive(false);
            Invoke("StartGame", 0.5f);

        }
    }

    public void StartGame()
    {
        isGameStarted = true;
    }

    public void Pause()
    {
        pause.SetActive(false);
        pausePanel.SetActive(true);

        Time.timeScale = 0f;
    }

    public void Resume()
    {
        Time.timeScale = 1f;

        pausePanel.SetActive(false);
        pause.SetActive(true);
    }

    public void Retry()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(levelNo);
    }

    public void Menu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Play");
    }

    public void Failed()
    {
        falseIcon.SetActive(false);

        isGameEnded = false;

        timeBarScript.enabled = true;
        SceneManager.LoadScene("Failed");
    }

    public void Won()
    {
        isGameEnded = false;
        chickenControl.timeScoreObj.SetActive(false);
        timeBarScript.enabled = true;
        trueIcon.SetActive(false);
        SceneManager.LoadScene("Won");
    }

    
}
