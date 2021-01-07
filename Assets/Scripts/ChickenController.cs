using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenController : MonoBehaviour
{
    public int totalScore;

    [SerializeField] private int score = 50;

    [SerializeField] private GameObject timeBar;
    TimeBarScript timeBarScript;

    public static bool collisionWithMud = false;
    private void Start()
    {
        timeBarScript = timeBar.GetComponent<TimeBarScript>();
    }
    private void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.tag == "score")
        {
            AddScore(score);
            Destroy(col.gameObject);
        }

        if (col.gameObject.tag == "coop")
        {
            GameManager.instance.trueIcon.SetActive(true);
            timeBarScript.enabled = false;
            GameManager.instance.Invoke("Won", 1.5f);
            gameObject.SetActive(false);
        }

        if (col.gameObject.tag == "mud")
        {
            collisionWithMud = true;
        }

    }

    private void OnCollisionExit(Collision col)
    {
        if (col.gameObject.tag == "mud")
        {
            collisionWithMud = false;
        }
    }

    void AddScore(int score)
    {
        totalScore += score;
    }
}
