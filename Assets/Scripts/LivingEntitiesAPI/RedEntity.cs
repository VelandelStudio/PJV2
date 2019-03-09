using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedEntity : LivingEntitiesMPL
{
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        enemy = GetComponent<EnemyImpl>();
        HP = 10;
        SetHP(10);
        Type = E_Type.red;
    }

    public override void PostDie()
    {
       
    }

    public override void PreDie()
    {
        //needs IEnemies for ScorePoints
        GameManagement.instance.Score += enemy.ScoreValue;
        anim.SetTrigger("isDead");
    }
}
