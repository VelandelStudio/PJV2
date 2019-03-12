using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedEnemyspawn : MonoBehaviour, ISpawnables
{
    public RedEnemyspawn redEnemypawn;
    private RedEntity enemy;
    private float timeToNextSpawn;

    public int MaxSpawn
    {
        get;
        protected set;
    }

    private void Start()
    {
        timeToNextSpawn = CalculTimeToNextSpawn();
    }

    private void Update()
    {
        timeToNextSpawn -= Time.deltaTime;

        if (timeToNextSpawn <= 0)
        {
            SpawnMob();

            timeToNextSpawn = CalculTimeToNextSpawn();
        }
    }
    
    public void SpawnMob()
    {
        Instantiate(enemy, transform.position, Quaternion.identity);
    }

    public float CalculTimeToNextSpawn()
    {
        float nextTime = 0f;

        nextTime = Random.Range(1f, 10f);

        return nextTime;
    }
}
