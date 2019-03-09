using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueEnemyStat : EnemyImpl
{
    void Awake()
    {
        DetectionField = 10;
        ScoreValue = 20;
    }
}
