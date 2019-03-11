using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueEnemyspawn : MonoBehaviour, ISpawnables
{
    public GameObject blueEnemyspawn;

    public int maxSpawn
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
    
    private void SpawnMob()
    {
        nbEnemies++;
        Instantiate(BlueEnemyISpawnable, transform.position, Quaternion.identity);
    }

    private float CalculTimeToNextSpawn()
    {
        float nextTime = 0f;

        nextTime = Random.Range(1f, 10f);

        return nextTime;
    }
    
    private bool MaxNbOfEnemies(){
        return (nbEnemies == maxOfEnemies);
    }
}
