using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BlueEnemy : MonoBehaviour {


    private Rigidbody rb;
    public string type = "blue";

    private int hp;
    private int scorePoints = 50;


    private void SetEnemyHp()
    {
        hp = GameManagement.instance.Level * 5 + 10;
    }

    private void BeKilled()
    {
        GameManagement.instance.Score += scorePoints;

        rb.isKinematic = true;

        Destroy(GetComponent<Collider>());
        Destroy(GetComponent<NavMeshAgent>());
        Destroy(gameObject, 5f); // 5f ?

    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();

        SetEnemyHp();
    }

    public void TakeDamage(int damage, BlueBullet bullet) // BlueBullet not created yet, see KB task : "Create game object Blue Bullet"
    {
        if (bullet.type == type)
        {
            hp -= damage;
        }
        else
        {
            Debug.Log("Wallah c'est pas les bonnes balles frèr");
        }

        if (hp <= 0)
        {
            BeKilled();
            // Explode(); Explode() not created yet, see KB task : "Create game object Explosion"
        }
    }






}
