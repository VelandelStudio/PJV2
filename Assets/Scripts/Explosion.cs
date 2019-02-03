using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    private int powerAttack;
    private SphereCollider myCollider;
    private float proximity;

    void Start()
    {   
        SetEnemyPower();
        myCollider = GetComponent<SphereCollider>();
    }

    void Update()
    {
        ExplosionEnd(); //don't really know where to put this one ...
    }

    public void OnTriggerEnter(Collider other)
    {
        // changes that could be reeeeaaally nice : 
        //one health script for everyone (player and enemy), one common tag 'ennemy' for all enemies
        if(other.GameObject.CompareTag("RedEnemy") || other.GameObject.CompareTag("BlueEnemy"))
        {
            other.TakeDamage(powerAttack * ProximityOfCenter(other), "explosion");
            
        }
        else if ( other.CompareTag("Player"))
        {
            other.TakeDamage(powerAttack * ProximityOfCenter(other));
        }

        PushBack(other);
    }

    private void SetEnemyPower()
    {
        powerAttack = GameManagement.instance.Level * 5;
    }

    //push the object away from the center of explosion, with a higher force if object is close to it.
    private void PushBack(Collider other)
    {
        otherRb = other.GetComponentInParent<Rigidbody>();
        otherTransform = other.GetComponentInParent<Transform>();
        otherRb.AddForce( -otherTransform.forward * ProximityOfCenter(other));
    }

    //closer the object is from the center, higher the impact of explosion will be.
    private int ProximityOfCenter(Collider other)
    {
        //if the object is really close to the center of explosion, proximity will be higher
        private Transform otherPos = other.GetComponentInParent<Transform>();
        float distance = Vector3.Distance(transform.position, otherPos.position);
        
        if(distance < 0)
        {
            proximity = myCollider.radius + distance;
        }
        else
        {
            proximity = myCollider.radius - distance;
        }
        if (proximity <= 0)
        {
            proximity = 0;
        }
        return (int)proximity;
    }

    private void ExplosionEnd()
    {
        rb.isKinematic = true;

        Destroy(GetComponent<Collider>());
        Destroy(gameObject, 5f);
    }
