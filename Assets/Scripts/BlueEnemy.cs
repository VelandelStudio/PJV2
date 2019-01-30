using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BlueEnemy : MonoBehaviour
{
    private Transform player;
    private RigidBody rb;
    private BlueKamikaze attack;

    public string type = 'blue';
    public int health = 20;
    public int score = 10;

    private void Awake(){
        rb = GetComponent<Rigidbody>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        attack = GetComponent<BlueKamikaze>();
        SetEnemyHP();
        SetEnemyScore();
    }

    private void Update(){
        if(health <= 0)
        {
            Die();
        }
        if(!attack.launched)
        {

        }
    }

    public void OnTriggerEnter(Collider Player)
    {
        attack.launched = true;
    }

    private void SetEnemyHP(){
        health = Health*GameManagement.instance.Level;
    }

    private void SetEnemyScore(){
        score = Score*GameManagement.instance.Level;
    }




    private void Die(){
        rigidbody.isKinematic = true;

        Destroy(GetComponent<Collider>());
        Destroy(GetComponent<NavMeshAgent>());
    }
}