using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public abstract class LivingEntitiesMPL : MonoBehaviour, ILivingEntities
{
    public int HpEntity;
    protected E_Type TypeEntity;
    protected Animator anim;
    protected Rigidbody rb;

    public int HP { get; protected set; }

    public E_Type Type { get; protected set; }

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
        rb.isKinematic = true;
        Destroy(GetComponent<Collider>());
        Destroy(GetComponent<NavMeshAgent>());
        Destroy(gameObject);
        PostDie();
    }

    public abstract void PreDie();
    public abstract void PostDie();
}
