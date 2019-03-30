using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public abstract class LivingEntitiesMPL : MonoBehaviour, ILivingEntities
{
    protected Animator anim;
    protected Rigidbody rb;
    protected EnemyImpl enemy;

    [SerializeField] private int hp;
    public int HP { get { return hp; } protected set { hp = value; } }

    [SerializeField] private E_Type type;
    public E_Type Type { get { return type; } protected set { type = value; } }

    public void SetHP(int HP)
    {
        HP = GameManagement.instance.Level * 5 + HP;
    }

    public void Takedamage(int damage, E_Type unknownType)
    {
        if (unknownType == Type)
        {
            HP -= damage;
        }
        else
        {
            Debug.Log("Immune");
        }

        if (HP <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        PreDie();
        if(rb)
        {
            rb.isKinematic = true;
        }

        Destroy(GetComponent<Collider>());
        if(GetComponent<NavMeshAgent>())
        {
            Destroy(GetComponent<NavMeshAgent>());
        }

        PostDie();
        Destroy(gameObject);
    }


    public abstract void PreDie();
    public abstract void PostDie();
}
