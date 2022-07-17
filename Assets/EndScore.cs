using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EndScore : MonoBehaviour
{

    public TMP_Text score;
    public int totalScore = Stopwatch.score + EnemyHealth.enemyScore;
    // Start is called before the first frame update
    void Start()
    {
        //public int totalScore = Stopwatch.score + EnemyHealth.enemyScore;
        score.text = totalScore + " POINTS"; 
        //score.text = totalScore.ToString() + " POINTS"; 
    }

}
