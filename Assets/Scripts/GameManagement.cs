using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// GameManagement : Warning, Singleton inside !
/// This Singleton is used to manage the Score and the level of every games.
/// </summary>
public class GameManagement : MonoBehaviour {

    public static GameManagement instance = null;

    public TimerGUI timer;

    private int score;
    public int Score
    {
        get { return score; }
        set { score = value; }
    }

    private int level;
    public int Level
    {
        get { return level; }
    }

    /// <summary>
    /// On Awake, we create the Singleton.
    /// </summary>
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

    /// <summary>
    /// On Start we reset every thing and load a new Level.
    /// </summary>
    private void Start()
    {
        Score = 0;
        level = 0;

        LoadNewLevel();
    }

    /// <summary>
    /// LoadNewLevel increas the Level of the game and resets the timer.
    /// </summary>
    public void LoadNewLevel()
    {
        level++;
        Debug.Log("Loading Level " + level);

        if (level > 1)
        {
            timer.ResetTime();
        }
    }
}
