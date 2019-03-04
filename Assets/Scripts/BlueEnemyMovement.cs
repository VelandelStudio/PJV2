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
    private BlueEnemy enemy;

    private float radius = 10f;
    Vector3 randomPointOnCircle;

    bool isOnTrack = false;
    float distToPlayer;
    int detectionDist = 10;
    int explodeDist = 0; // On pourrait récuperer la portée de l'explosion et la mettre en explodeDist

    /*private BezierWalkerWithSpeed move;
    private BezierSpline pattern;*/
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
        /*move = GetComponent<BezierWalkerWithSpeed>();
        move.enabled = false;*/
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
            /*if(!isNotOnTrack)
            {
                //pour éviter la surcharge d'objet bézier Spline
                move.enabled = false;
                Object.Destroy(obj: pattern);
                nav.enabled = true;
            }*/
        
            if (distToPlayer > explodeDist) //  If the enemy too far from player to explode
            {
                nav.destination = player.position;
            }
            else
            {                            // The enemy is close enough to explode
                Instantiate(boom, transform.position, transform.rotation);
                enemy.BeKilled();
            }
        }else{
            if (isNotOnTrack(transform.position, randomPointOnCircle) && !isOnTrack)
            {
                MoveToLocation(randomPointOnCircle);
            } 
            else 
            {
                isOnTrack = true;
                Vector3 start = transform.position;
                Vector3 finish = new Vector3 (start.x+5, start.y, start.z + 5);
                MoveToLocation(finish);

                /*nav.enabled = false;
                isNotOnTrack = false;
            //we suppose that the game object blueEnemy has already
            // a component BezierWalker but empty and disabled
            //we add a pattern that we create and we enable the movement.
                pattern = BlueEnemyPattern.create(transform.position);
                move.spline = pattern;
                move.enabled = true;*/
            }
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
    }

    public bool isNotOnTrack(Vector3 position, Vector3 start)
    {
        return (Vector3.Distance(position, start)>0);
    }

    /// <summary>
    /// RandomOnUnitSphere method
    /// </summary>
    /// <returns>A random point on the circle surrounding the spawn point</returns>
    private Vector3 RandomOnUnitSphere()
    {
        Random.InitState(System.DateTime.Now.Millisecond);
        Vector3 randomPointOnCircle = new Vector3(Random.insideUnitCircle.x , transform.position.y, Random.insideUnitCircle.y);
        randomPointOnCircle.Normalize();
        randomPointOnCircle *= radius;
        return randomPointOnCircle;
    }
}