using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueEntity : LivingEntitiesMPL
{
    private BlueSpawner spawner;
    void Awake()
    {
        enemy = GetComponent<EnemyImpl>();
        rb = GetComponent<Rigidbody>();
        //NB of HP of BlueEnemy
        HP = 5;
        //nb of HP depends on the Level number
        SetHP(HP);
        Type = E_Type.blue;

        spawner = GameObject.FindObjectOfType<BlueSpawner>();
    }

    public override void PostDie(){}

    public override void PreDie()
    {
        GameManagement.instance.Score += enemy.ScoreValue;
        //Instantiate(boom, transform.position, transform.rotation);
        spawner.nbEnemies--;
    }
}
