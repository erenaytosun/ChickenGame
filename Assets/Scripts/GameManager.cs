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
    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);

        chickenControl = chicken.GetComponent<ChickenController>();
        pauseButton.onClick.AddListener(Pause);
        resumeButton.onClick.AddListener(Resume);
        menuButton.onClick.AddListener(Menu);
        retryButton.onClick.AddListener(Retry);

        isGameStarted = true;
    }

    void Update()
    {
        scoreText.text = "score: " + chickenControl.totalScore;
    }

    void Pause()
    {
        pause.SetActive(false);
        pausePanel.SetActive(true);

        Time.timeScale = 0f;
    }

    void Resume()
    {
        Time.timeScale = 1f;

        pausePanel.SetActive(false);
        pause.SetActive(true);
    }

    void Retry()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    void Menu()
    {
        Time.timeScale = 1f;
    }

    public void Failed()
    {
        falseIcon.SetActive(false);
        SceneManager.LoadScene("Failed");
    }

    public void Won()
    {
        trueIcon.SetActive(false);
        SceneManager.LoadScene("Won");
    }
}
