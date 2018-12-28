using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

/// <summary>
/// RedEnemy Class
/// This is the class that manage life and death of the red dog in game.
/// </summary>
public class RedEnemy : MonoBehaviour {

    private Animator anim;
    private Rigidbody rb;
    [SerializeField]
    private List<ParticleSystem> PS_DogDies = new List<ParticleSystem>();

    public string type = "red";

    private int hp;
    private int scorePoints = 30;
    
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();

        SetEnemyHp();
    }

    /// <summary>
    /// TakeDamage method.
    /// Usable when RedEnemy is get by an entity that deals damages.
    /// </summary>
    /// <param name="damage">The number of damage you want to Apply</param>
    /// <param name="bullet">The RedBullet that touch the RedEnemy</param>
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

    /// <summary>
    /// BeKilled Method called if TakeDamage method turn life of the enemy to Zero.
    /// </summary>
    private void BeKilled()
    {
        GameManagement.instance.Score += scorePoints;

        anim.SetTrigger("isDead");
        rb.isKinematic = true;

        Destroy(GetComponent<Collider>());
        Destroy(GetComponent<NavMeshAgent>());
        Destroy(gameObject, 5f);
        for(int i = 0; i < PS_DogDies.Count; i++)
        {
            PS_DogDies[i].Play(true);
        }
    }

    /// <summary>
    /// SetEnemyHp Method
    /// Set the life of the enemy depending on the current level
    /// </summary>
    private void SetEnemyHp()
    {
        hp = GameManagement.instance.Level * 10 + 20;
    }
}