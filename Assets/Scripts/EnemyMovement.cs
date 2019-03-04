using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

/// <summary>
/// EnemyMovement class is used to make ennemies move and catch the player.
/// </summary>
public class EnemyMovement : MonoBehaviour {

    Transform player;
    NavMeshAgent nav;
    EnemyAttack enemyAttack;

    /// <summary>
    /// On Awake, we get the ennemy components such as NavMeshAgent and EnnemyAttack.
    /// We also get an instance of the player.
    /// </summary>
    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        nav = GetComponent<NavMeshAgent>();
        enemyAttack = GetComponent<EnemyAttack>();
    }

    /// <summary>
    /// On Update, first we ceck if the navMeshAgent is not null.
    /// If the ennemy is not attacking, he moves.
    /// </summary>
    private void Update()
    {
        if (nav)
        {
            if (enemyAttack.isAttacking)
            {
                nav.isStopped = true;
            }
            else
            {
                MoveToLocation(player.position);
            }
        }
    }

    public void MoveToLocation(Vector3 targetPoint)
    {
        nav.destination = targetPoint;
        nav.isStopped = false;
    }
}
