using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreGUI : MonoBehaviour {

    public Text scoreLabel;

    private int actualScore; 

    private void OnGUI()
    {
        if (actualScore != GameManagement.instance.Score)
        {
            actualScore = GameManagement.instance.Score;
            scoreLabel.text = "Score : " + actualScore;
        }
    }
}
