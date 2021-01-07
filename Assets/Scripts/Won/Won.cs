using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Won : MonoBehaviour
{
    [SerializeField] private Button nextButton;

    private int level;

    private void Start()
    {
        nextButton.onClick.AddListener(NextLevel);
    }

    public void NextLevel()
    {
        level = PlayerPrefs.GetInt("level");

        //SceneManager.LoadScene(level + 1); 
    }   


}