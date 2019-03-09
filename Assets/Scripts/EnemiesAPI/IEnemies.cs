using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEnemies {

    int DetectionField { get; }
    int ScoreValue { get; }

    //Attack[] Attacks { get; }
    //Movement[] Movements { get; }
}
