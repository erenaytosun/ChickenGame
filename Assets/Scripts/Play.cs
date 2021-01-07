using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Play : MonoBehaviour
{
    [SerializeField] private Button playButton;

    private int level;

    void Start()
    {
        playButton.onClick.AddListener(PlayGame);
    }

    public void PlayGame()
    {
        GameManager.isGameStarted = true;
        
        level = PlayerPrefs.GetInt("level");

        if(level == 0)
            SceneManager.LoadScene(3);
        else
            SceneManager.LoadScene(level);

    }
}
