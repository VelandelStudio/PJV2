using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// RedSpawner Class
/// The object that manage the spawn(appearance) of an enemy in the game
/// </summary>
public class RedSpawner : MonoBehaviour {

    public RedEnemy redEnemy;

    private float timeToNextSpawn;

    private void Start()
    {
        timeToNextSpawn = CalculTimeToNextSpawn();
    }

    /// <summary>
    /// Update methode
    /// the methode spawn an enemy each time the new timer to spawn equals zero
    /// </summary>
    private void Update()
    {
        timeToNextSpawn -= Time.deltaTime;

        if (timeToNextSpawn <= 0)
        {
            SpawnMob();

            timeToNextSpawn = CalculTimeToNextSpawn();
        }
    }

    /// <summary>
    /// SpawnMob method
    /// Just call the instantiate Unity method to permit a monster to spawn in the world
    /// </summary>
    private void SpawnMob()
    {
        Instantiate(redEnemy, transform.position, Quaternion.identity);
    }

    /// <summary>
    /// CalculTimeToNextSpawn Method
    /// Calcul a new random number used to spawn a monster
    /// </summary>
    /// <returns>A new random time for the next Spawn</returns>
    private float CalculTimeToNextSpawn()
    {
        float nextTime = 0f;

        nextTime = Random.Range(1f, 10f);

        return nextTime;
    }
}
