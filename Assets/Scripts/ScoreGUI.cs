

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// UI of the score of the player
/// </summary>
public class ScoreGUI : MonoBehaviour {

    public Text scoreLabel;

    private int actualScore; 

    /// <summary>
    /// Set and print the score on UI when the player Scores
    /// </summary>
    private void OnGUI()
    {
        if (actualScore != GameManagement.instance.Score)
        {
            actualScore = GameManagement.instance.Score;
            scoreLabel.text = "Score : " + actualScore;
        }
    }
}
