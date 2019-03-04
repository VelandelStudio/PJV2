using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BlueTitouan1 : MonoBehaviour
{
    Transform player;
    NavMeshAgent nav;
    float distToPlayer;
    int detectionDist = 10;
    int explodeDist = 1; // On pourrait récuperer la portée de l'explosion et la mettre en explodeDist


    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        nav = GetComponent<NavMeshAgent>();
        distToPlayer = Vector3.Distance(player.position, transform.position);

    }

 
    private void Update()
    {
        if (distToPlayer < detectionDist)  // If the enemy is close enough to detect player
        {
            if (distToPlayer > explodeDist) //  If the enemy too far from player to explode
                nav.destination = player.position;
            else                            // The enemy is close enough to explode
                Debug.Log("kaboom");
        }
        else
        {
            nav.destination = RandomNavSphere(transform.position, 20, 10); //layermask = A mask specifying which NavMesh areas are allowed when finding the nearest point.
        }


    }

    /// <summary>
    /// Move the enemy to the target location.
    /// </summary>
    /// <param name="targetPoint"></param>
    public void MoveToLocation(Vector3 targetPoint)
    {
        nav.destination = targetPoint;
        nav.isStopped = false;
    }

    public static Vector3 RandomNavSphere(Vector3 origin, float dist, int layermask)
    {
        Vector3 randDirection = Random.insideUnitSphere * dist;

        randDirection += origin;

        NavMeshHit navHit;

        NavMesh.SamplePosition(randDirection, out navHit, dist, layermask);

        return navHit.position;
    }
}
