using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RedEnemy : MonoBehaviour {

    private Animator anim;
    private Rigidbody rb;
    [SerializeField]
    private List<ParticleSystem> PS_DogDies = new List<ParticleSystem>();

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
        Destroy(gameObject, 5f);
        for(int i = 0; i < PS_DogDies.Count; i++)
        {
            PS_DogDies[i].Play(true);
        }
    }
}
