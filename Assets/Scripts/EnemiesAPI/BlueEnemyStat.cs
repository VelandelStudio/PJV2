﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueEnemyStat : EnemyImpl
{
    public override void AttributeValues()
    {
        DetectionField = 1500;
        ScoreValue = 20;
    }
}
