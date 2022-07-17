using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOverScreen : MonoBehaviour
{
    public TMP_Text pointsText;

    public void setUp(int score) 
    {
        gameObject.SetActive(true);
        pointsText.text = score.ToString() + " POINTS";
    }

    public void restartButton()
    {
        SceneManager.LoadScene("Game"); //Put name of the scene inside this method
    }

    public void exitButton()
    {
        SceneManager.LoadScene("MainMenu"); //Put name of the menu screen scene inside this method
    }
}
