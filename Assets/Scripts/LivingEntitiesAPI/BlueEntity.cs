using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueEntity : LivingEntitiesMPL
{
    private BlueSpawner spawner;
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        spawner = GameObject.FindObjectOfType<BlueSpawner>();

        SetHP();
    }

    public override void PostDie(){}

    public override void PreDie()
    {
        GameManagement.instance.Score += scorePoints;
        //Instantiate(boom, transform.position, transform.rotation);
        spawner.nbEnemies--;
    }
}
