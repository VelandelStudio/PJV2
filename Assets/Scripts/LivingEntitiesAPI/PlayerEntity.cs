using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEntity : LivingEntitiesMPL
{
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        //NB of HP of BlueEnemy
        HP = 150;
        Type = E_Type.player;
    }

    public override void PostDie()
    {
    }

    public override void PreDie()
    {
    }
}
