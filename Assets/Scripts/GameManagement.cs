using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    private void Start()
    {
        Score = 0;
        level = 0;

        LoadNewLevel();
    }

    public void LoadNewLevel()
    {
        level++;

        Debug.Log("Loading Level " + level);

        //Intantiate object for the lvl

        if (level > 1)
        {
            timer.ResetTime();
        }
    }
}
