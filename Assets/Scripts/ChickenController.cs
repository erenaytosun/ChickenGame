using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenController : MonoBehaviour
{
    public int totalScore;

    [SerializeField] private int score = 50;

    private void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.tag == "score")
        {
            AddScore(score);
            Destroy(col.gameObject);
        }
    }
    void AddScore(int score)
    {
        totalScore += score;
    }
}
