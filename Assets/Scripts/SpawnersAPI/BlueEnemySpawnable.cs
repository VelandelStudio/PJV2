using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueEnemyspawn : MonoBehaviour, ISpawnables
{
    public BlueEntity enemy;

    public int MaxSpawn
    {
        get;
        protected set;
    }

    private float timeToNextSpawn;
    private Transform[] spawnPoints;
    public int nbEnemies;
    public int maxOfEnemies = 5;         

    private void Start()
    {
        timeToNextSpawn = CalculTimeToNextSpawn();
        nbEnemies = 0;
    }
   
    private void Update()
    {
        timeToNextSpawn -= Time.deltaTime;

        if (timeToNextSpawn <= 0 && !MaxNbOfEnemies())
        {
            SpawnMob();

            timeToNextSpawn = CalculTimeToNextSpawn();
        }
    }
    
    public void SpawnMob()
    {
        nbEnemies++;
        Instantiate(enemy, transform.position, Quaternion.identity);
    }

    public float CalculTimeToNextSpawn()
    {
        float nextTime = 0f;

        nextTime = Random.Range(1f, 10f);

        return nextTime;
    }
    
    private bool MaxNbOfEnemies(){
        return (nbEnemies == maxOfEnemies);
    }
}
