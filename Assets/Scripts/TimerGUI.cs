using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerGUI : MonoBehaviour {

    public Text timerLabel;
    public Text gameOver;
    
    private float time = 121f;

    private void Start()
    {
        gameOver.enabled = false;
    }

    private void Update()
    {
        time -= Time.deltaTime;

        if (time >= 0f)
        {
            PrintTime();
        }
 
        if (time <= 0f)
        {
            DisplayGameOver();
        }
    }

    private void PrintTime()
    {
        float minutes = (time / 60) - 0.5f;
        float seconds = (time % 60) - 0.5f;

        timerLabel.text = "Timer " + string.Format("{0:00} : {1:00}", minutes, seconds);
    }

    private void DisplayGameOver()
    {
        gameOver.enabled = true;
    }
}
