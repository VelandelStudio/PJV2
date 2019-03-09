using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public abstract class LivingEntitiesMPL : MonoBehaviour, ILivingEntities
{
    private Rigidbody rb;
    private int HpEntity;
    private E_Type TypeEntity;


    public int HP
    {
        get
        {
            return HP;    
        }

        protected set
        {
            HP = HpEntity;
        }
    }

    public E_Type Type
    {
        get
        {
            return Type;
        }

        protected set
        {
            Type = TypeEntity;
        }
    }

    public void SetHP(int HP)
    {
        HP = GameManagement.instance.Level * 5 + 10;
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
