using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenEntity : LivingEntitiesMPL
{
    [SerializeField] private GameObject RedBoostBox;
    public override void PostDie()
    {
        Instantiate(RedBoostBox, transform.position, Quaternion.identity);
    }

    public override void PreDie()
    {
    }

}
