using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Text scoreText;
    [SerializeField] private GameObject chicken;
    ChickenController chickenControl;

    [SerializeField] private Button pauseButton;
    [SerializeField] private Button resumeButton;
    [SerializeField] private Button menuButton;
    [SerializeField] private Button retryButton;

    [SerializeField] private GameObject gamePanel;
    [SerializeField] private GameObject pausePanel;

    [SerializeField] private GameObject pause;
    public GameObject trueIcon;
    public GameObject falseIcon;

    public static GameManager instance;
    public static bool isGameStarted = false;
    public static bool isGameEnded = false;

    public int levelNo;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);

        PlayerPrefs.SetInt("level", 3);
        levelNo = PlayerPrefs.GetInt("level");

        gamePanel.SetActive(true);
        chickenControl = chicken.GetComponent<ChickenController>();

        pauseButton.onClick.AddListener(Pause);
        resumeButton.onClick.AddListener(Resume);
        menuButton.onClick.AddListener(Menu);
        retryButton.onClick.AddListener(Retry);
    }

    void Update()
    {
        scoreText.text = "score: " + chickenControl.totalScore;
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
    }

    public void Failed()
    {
        falseIcon.SetActive(false);

        isGameEnded = false;

        SceneManager.LoadScene("Failed");
    }

    public void Won()
    {
        trueIcon.SetActive(false);
        SceneManager.LoadScene("Won");
    }
}
