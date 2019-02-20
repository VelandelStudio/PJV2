using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using BezierSolution;

/// <summary>
/// EnemyDefaultLocation class is used to determine whether enemies will attack the player, keep moving with a default pattern or move to a default location positioned on a circle surrounding the spawn point
/// </summary>
public class BlueEnemyMovement : MonoBehaviour
{
    Transform player;
    NavMeshAgent nav;
    public float radius = 10f;
    Vector3 randomPointOnCircle;
    float distToPlayer;
    int detectionDist = 5;
    int explodeDist = 0; // On pourrait récuperer la portée de l'explosion et la mettre en explodeDist
    private BlueEnemy enemy;
    private BezierWalkerWithSpeed move;
    private BezierSpline pattern;
    private bool notOnTrack = true;
    public Explosion boom;

    /// <summary>
    /// At the beginning, we get the ennemy components such as NavMeshAgent and EnnemyAttack
    /// We also get an instance of the player and the distance to the player
    /// </summary>
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        enemy = GetComponent<BlueEnemy>();
        nav = GetComponent<NavMeshAgent>();
        distToPlayer = Vector3.Distance(player.position, transform.position);
        //for pattern
        move = GetComponent<BezierWalkerWithSpeed>();
        move.enabled = true;
    }

    /// <summary>
    /// In Update, first we check if the player is inside the detection zone, he's atacked by the enemy
    /// then, if the ennemy is at his default location, he moves with a default pattern
    /// Finally, if the enemy isn't at his defaul location, he goes to it  
    /// </summary>
    private void Update()
    {
        randomPointOnCircle = RandomOnUnitSphere();
        if (distToPlayer <= detectionDist) 
        {
            if(!notOnTrack)
            {
                move.enabled = false;
                Object.Destroy(obj: pattern);
            }
            
            if (distToPlayer > explodeDist) //  If the enemy too far from player to explode
            {
                nav.destination = player.position;
            }
            else
            {                            // The enemy is close enough to explode
                Instantiate(boom, transform.position, transform.rotation);
                enemy.BeKilled();
            }
        }

        else if (Vector3.Distance(randomPointOnCircle, transform.position) <= 0f && notOnTrack)     
        {
            notOnTrack = false;
            //we suppose that the game object blueEnemy has already
            // a component BezierWalker but empty and disabled
            //we add a pattern that we create and we enable the movement.
            pattern = BlueEnemyPattern.create(transform.position);
            move.spline = pattern;
            move.enabled = true;
        }

        else if (notOnTrack)
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
    private Vector3 RandomOnUnitSphere()
    {
        Vector3 randomPointOnCircle = Random.insideUnitSphere;
        randomPointOnCircle.Normalize();
        randomPointOnCircle *= radius;
        return randomPointOnCircle;
    }
}