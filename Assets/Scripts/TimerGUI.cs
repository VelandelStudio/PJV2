using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// TimerGUI Class
/// Manage the time in a level and the Graphic aaspect during the game.
/// </summary>
public class TimerGUI : MonoBehaviour {

    public Text timerLabel;
    public Text gameOver;

    private float currentTime = 121f;

    private void Start()
    {
        gameOver.enabled = false;
    }

    private void Update()
    {
        currentTime -= Time.deltaTime;

        if (currentTime >= 0f)
        {
            PrintTime();
        }
 
        if (currentTime <= 0f)
        {
            DisplayGameOver();
        }
    }

    /// <summary>
    /// PrintTime Method
    /// Just set the current time and print it on the Screen
    /// </summary>
    private void PrintTime()
    {
        float minutes = (currentTime / 60) - 0.5f;
        float seconds = (currentTime % 60) - 0.5f;

        timerLabel.text = "Timer " + string.Format("{0:00} : {1:00}", minutes, seconds);
    }

    /// <summary>
    /// DisplayGameOver Method
    /// Print the GameOverLabel if the timer is at zero
    /// </summary>
    private void DisplayGameOver()
    {
        gameOver.enabled = true;
    }

    /// <summary>
    /// ResetTime Method
    /// Used by the GameManager
    /// </summary>
    public void ResetTime()
    {
        currentTime = 121f;
    }
}
