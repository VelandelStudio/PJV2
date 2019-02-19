using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

/// <summary>
/// EnemyDefaultLocation class is used to determine whether enemies will attack the player, keep moving with a default pattern or move to a default location positioned on a circle surrounding the spawn point
/// </summary>
public class EnemyDefaultLocation : MonoBehaviour
{
    Transform player;
    NavMeshAgent nav;
    Vector3 randomPointOnCircle;
    float distToPlayer;
    int detectionDist = 30;
    EnemyAttack enemyAttack;

    /// <summary>
    /// At the beginning, we get the ennemy components such as NavMeshAgent and EnnemyAttack
    /// We also get an instance of the player and the distance to the player
    /// </summary>
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        nav = GetComponent<NavMeshAgent>();
        enemyAttack = GetComponent<EnemyAttack>();
        distToPlayer = Vector3.Distance(player.position, transform.position);
        randomPointOnCircle = RandomOnUnitSphere();
    }

    /// <summary>
    /// In Update, first we check if the player is inside the detection zone, he's atacked by the enemy
    /// then, if the ennemy is at his default location, he moves with a default pattern
    /// Finally, if the enemy isn't at his defaul location, he goes to it  
    /// </summary>
    private void Update()
    {
        if (distToPlayer <= detectionDist) 
        {
            enemyAttack();
        }

        else if (Vector3.Distance(randomPointOnCircle, transform.position) = 0f)     
        {
            defaultmovement();
        }

        else
        {
            MoveToLocation(randomPointOnCircle);
        }
    }

    /// <summary>
    /// MoveToLocation method
    /// Move the enemy to the target location.
    /// </summary>
    /// <param name="targetPoint"></param>
    public void MoveToLocation(Vector3 targetPoint)
    {
        nav.destination = targetPoint;
        nav.isStopped = false;
    }

    /// <summary>
    /// RandomOnUnitSphere method
    /// </summary>
    /// <returns>A random point on the circle surrounding the spawn point</returns>
    public static Vector3 RandomOnUnitSphere()
    {
        float radius;
        Vector3 randomPointOnCircle = Random.insideUnitSphere;
        randomPointOnCircle.Normalize();
        randomPointOnCircle *= radius;
        return randomPointOnCircle;
    }
}