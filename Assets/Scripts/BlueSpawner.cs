using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// BlueSpawner Class
/// The object that manage the spawn(appearance) of the blue enemy in the game
/// An array of spawn points from where the blue enemy can spawn
/// </summary>
public class BlueSpawner : MonoBehaviour
{

    public GameObject blueEnemy;

    private float timeToNextSpawn;

    private Transform[] spawnPoints;
    public int nbEnemies;
    public int maxOfEnemies = 5;         

    private void Start()
    {
        timeToNextSpawn = CalculTimeToNextSpawn();
        nbEnemies = 0;
    }

    /// <summary>
    /// Update methode
    /// The methode spawn an enemy each time the new timer to spawn equals zero
    /// </summary>
    private void Update()
    {
        timeToNextSpawn -= Time.deltaTime;

        if (timeToNextSpawn <= 0 && !MaxNbOfEnemies())
        {
            SpawnMob();

            timeToNextSpawn = CalculTimeToNextSpawn();
        }
    }

    /// <summary>
    /// SpawnMob method
    /// Find a random index between zero and one less than the number of spawn points
    /// Just call the instantiate Unity method to permit an enemy to spawn in the world
    /// </summary>
    private void SpawnMob()
    {
        nbEnemies++;
        Instantiate(blueEnemy, transform.position, Quaternion.identity);
    }

    /// <summary>
    /// CalculTimeToNextSpawn Method
    /// Calcul a new random number used to spawn an enemy
    /// </summary>
    /// <returns>A new random time for the next Spawn</returns>
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
