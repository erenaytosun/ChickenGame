using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Won : MonoBehaviour
{
    [SerializeField] private Button nextButton;

    private void Start()
    {
        nextButton.onClick.AddListener(NextLevel);
    }

    public void NextLevel()
    {
        SceneManager.LoadScene("Level1");
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }   


}