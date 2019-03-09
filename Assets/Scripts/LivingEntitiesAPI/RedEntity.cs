using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedEntity : LivingEntitiesMPL
{
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        HP = 10;
        SetHP(10);
        Type = E_Type.red;
    }

    public override void PostDie()
    {
        for (int i = 0; i < PS_DogDies.Count; i++)
        {
            PS_DogDies[i].Play(true);
        }
    }

    public override void PreDie()
    {
        //needs IEnemies for ScorePoints
        GameManagement.instance.Score += scorePoints;
        anim.SetTrigger("isDead");
    }
}
