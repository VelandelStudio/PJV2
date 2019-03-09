using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedEntity : LivingEntitiesMPL
{
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();

        SetHP();
    }

    public override void PostDie()
    {
       
    }

    public override void PreDie()
    {
      
    }
}
