using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    private void PrintTime()
    {
        float minutes = (currentTime / 60) - 0.5f;
        float seconds = (currentTime % 60) - 0.5f;

        timerLabel.text = "Timer " + string.Format("{0:00} : {1:00}", minutes, seconds);
    }

    private void DisplayGameOver()
    {
        gameOver.enabled = true;
    }

    public void ResetTime()
    {
        currentTime = 121f;
    }
}
