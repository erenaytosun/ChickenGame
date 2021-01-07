using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeBarScript : MonoBehaviour
{
    Image timeBar;
    [SerializeField] private float maxTime = 5f;
    private float timeLeft;
    [SerializeField] private GameObject timesUpText;

    void Start()
    {
        timesUpText.SetActive(false);
        timeBar = GetComponent<Image>();
        timeLeft = maxTime;
    }

    void Update()
    {
        if(timeLeft > 0)
        {
            timeLeft -= Time.deltaTime;
            timeBar.fillAmount = timeLeft / maxTime;
        }
        else
        {
            timesUpText.SetActive(true);
            //Time.timeScale = 0f;
            GameManager.instance.Invoke("Failed", 1.5f);
        }
    }
}
