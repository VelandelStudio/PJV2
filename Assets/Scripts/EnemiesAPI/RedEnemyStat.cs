using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedEnemyStat : EnemyImpl
{
    void Awake()
    {
        DetectionField = 6;
        ScoreValue = 15;
        ForceIndividu = 3;
    }
}
