using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenEnemyStat : EnemyImpl
{
    public override void AttributeValues()
    {
        DetectionField = 125;
        ScoreValue = 10;
        ForceIndividu = 50;
    }
}
