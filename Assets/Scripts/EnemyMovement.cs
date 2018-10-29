using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour {

    Transform player;
    NavMeshAgent nav;
    EnemyAttack enemyAttack;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        nav = GetComponent<NavMeshAgent>();
        enemyAttack = GetComponent<EnemyAttack>();
    }

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
