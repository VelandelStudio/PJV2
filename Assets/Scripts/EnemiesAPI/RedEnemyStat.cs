using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedEnemyStat : EnemyImpl
{
    public override void AttributeValues()
    {
        DetectionField = 6;
        ScoreValue = 15;
        ForceIndividu = 3;
    }
}
