using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedSpawner : MonoBehaviour {

    public RedEnemy redEnemy;

    private float timeToNextSpawn;

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
        Instantiate(redEnemy, transform.position, Quaternion.identity);
    }

    private float CalculTimeToNextSpawn()
    {
        float nextTime = 0f;

        nextTime = Random.value * 10;

        return nextTime;
    }
}
