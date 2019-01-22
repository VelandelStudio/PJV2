using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueEnemy : MonoBehavior{
    private Transform player;
    private RigidBody rigidbody;

    private bool explodes = false;

    private float detectionfield = 5f;
    private float speed = 2f;

    public String type = 'blue';
    public int health = 20;
    public int score = 10; 

    private void Awake(){
        rigidbody = GetComponent<Rigidbody>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        SetEnemyHP();
        SetEnemyScore();
    }

    private void Update(){
        float distance = Vector3.distance(transform.position, player.position);
        if (distance < detectionfield)
            if(distance == 0)
                Kamikaze();
            else{
                speed = 3f;
                //clignotement ?
            }
    }

    private void SetEnemyHP(){
        health = Health*GameManagement.instance.Level;
    }

    private void SetEnemyScore(){
        score = Score*GameManagement.instance.Level;
    }

    private void Kamikaze(){
        EnemyAttack enemyAttack = GetComponent<EnemyAttack>();
        enemyAttack.isAttacking = true;
        Explosion();
        Die();
    }

    private void Die(){
        health = 0;
        rigidbody.isKinematic = true;

        Destroy(GetComponent<Collider>());
        Destroy(GetComponent<NavMeshAgent>());
    }

    private void Explosion(){
        //démarrage animation
        //détection des autres ennemis dans champ d'action + dégats ???
    }
}