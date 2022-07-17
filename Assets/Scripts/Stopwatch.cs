using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class Stopwatch : MonoBehaviour
{
    bool stopwatchActive = false;
    public float currentTime;
    public Text currentTimeText;

    public static int score;
    public Text scoreText;
    //public TMP_Text totalScoreText;
    public float multiplier = 5;

    // Start is called before the first frame update
    void Start()
    {
        currentTime = 0;
        stopwatchActive = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (stopwatchActive == true)
        {
            currentTime = currentTime + Time.deltaTime;
        }

        //Score for game
        score = Mathf.RoundToInt(currentTime * multiplier);

        //Print stopwatch
        scoreText.text = score.ToString();
        TimeSpan time = TimeSpan.FromSeconds(currentTime);
        currentTimeText.text = time.ToString(@"mm\:ss\:fff");
        //totalScoreText.text = score.ToString() + " POINTS";
    }

    public void startStopwatch()
    {
        stopwatchActive = true;
    }

    public void stopStopwatch()
    {
        stopwatchActive = false;
    }
}
