using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Failed : MonoBehaviour
{
    [SerializeField] private Button retryButton;

    private int levelNo;

    private void Start()
    {
        retryButton.onClick.AddListener(Retry);
    }

    public void Retry()
    {
        Time.timeScale = 1f;

        levelNo = PlayerPrefs.GetInt("level");
        SceneManager.LoadScene(levelNo);
    }

}