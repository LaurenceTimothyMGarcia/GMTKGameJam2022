using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class Stopwatch : MonoBehaviour
{
    bool stopwatchActive = false;
    float currentTime;
    public TMP_Text currentTimeText;

    int score;
    public TMP_Text scoreText;
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
