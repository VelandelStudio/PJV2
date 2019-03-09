using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyImpl : MonoBehaviour, IEnemies
{

    public int DetectionField
    {
        get;
        protected set;
    }
    public int ScoreValue
    {
        get;
        protected set;
    }
    /*
     Attack[] Attacks {get;}
     Movement[] Movements {get;}
    */
}
 