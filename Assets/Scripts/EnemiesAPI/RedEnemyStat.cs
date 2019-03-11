using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedEnemyStat : EnemyImpl
{
    void Awake()
    {
        DetectionField = 1;
        ScoreValue = 15;
        forceIndividu =3;
    }
}
