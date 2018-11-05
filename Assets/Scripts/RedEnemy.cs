using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RedEnemy : MonoBehaviour {

    private Animator anim;
    private Rigidbody rb;

    public string type = "red";

    private int hp = 30;
    private int scorePoints = 30;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }

    public void TakeDamage(int damage, RedBullet bullet)
    {
        if (bullet.type == type)
        {
            hp -= damage;
        }
        else
        {
            Debug.Log("Immune Asooooo");
        }

        if (hp <= 0)
        {
            BeKilled();
        }
    }

    private void BeKilled()
    {
        GameManagement.instance.Score += scorePoints;

        anim.SetTrigger("isDead");
        rb.isKinematic = true;

        Destroy(GetComponent<Collider>());
        Destroy(GetComponent<NavMeshAgent>());
        Destroy(gameObject, 2f);
    }
}
