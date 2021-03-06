﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BlueEnemy : MonoBehaviour {

    public string type = "blue";
    public Explosion boom;

    private int hp;
    private int scorePoints = 50;
    private BlueSpawner spawner;
    private Rigidbody rb;


    private void SetEnemyHp()
    {
        hp = GameManagement.instance.Level * 5 + 10;
    }

    public void Die()
    {
        rb.isKinematic = true;
        spawner.nbEnemies --;
        Destroy(GetComponent<Collider>());
        Destroy(GetComponent<NavMeshAgent>());
        Destroy(gameObject);
    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        spawner = GameObject.FindObjectOfType<BlueSpawner>();

        SetEnemyHp();
    }

    ///modification from 'blueBullet type' to string 'otherType', to implement damages through explosion
    public void TakeDamage(int damage, string otherType) // BlueBullet not created yet, see KB task : "Create game object Blue Bullet"
    {
        if (otherType == type || otherType == "explosion")
        {
            hp -= damage;
        }
        else
        {
            Debug.Log("Immune");
        }

        if (hp <= 0)
        {
            //Not sure about how the instantiate function works. 
            GameManagement.instance.Score += scorePoints;
            GetComponent<BlueBehaviour>().Explodes();
            Die();
        }
    }

}
