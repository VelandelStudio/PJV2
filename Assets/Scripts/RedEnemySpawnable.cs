using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedEnemyISpawnable : MonoBehaviour, ISpawnables
{
    public RedEnemyISpawnable redEnemyISpawnable;

    private float timeToNextSpawn;

    public int maxSpawn
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
    
    private void SpawnMob()
    {
        Instantiate(redEnemyISpawnable, transform.position, Quaternion.identity);
    }

    private float CalculTimeToNextSpawn()
    {
        float nextTime = 0f;

        nextTime = Random.Range(1f, 10f);

        return nextTime;
    }
}
