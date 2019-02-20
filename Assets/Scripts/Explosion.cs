using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public int powerAttack;
    private SphereCollider myCollider;
    private float proximity;

    void Start()
    {
        SetEnemyPower();
        myCollider = GetComponent<SphereCollider>();
    }

    void Update()
    {
        //ExplosionEnd(); //As the explosion only exist for an instant, end seems to be fitting here 
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("RedEnemy"))
        {
            RedEnemy enemy = other.GetComponent<RedEnemy>();
            enemy.TakeDamage(DamageQuantity(other), "explosion");

        }
        else if (other.CompareTag("BlueEnemy"))
        {
            BlueEnemy enemy = other.GetComponent<BlueEnemy>();
            enemy.TakeDamage(DamageQuantity(other), "explosion");
        }
        else if (other.CompareTag("Player"))
        {
            PlayerHealth player = other.GetComponentInParent<PlayerHealth>();
            player.TakeDamage(DamageQuantity(other));
            CharacterController controller = other.GetComponentInParent<CharacterController>();
            controller.enabled = false;
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
        Rigidbody rb1 = other.GetComponentInParent<Rigidbody>();
        rb1.AddExplosionForce(powerAttack*1000, transform.position, myCollider.radius);
    }

    //closer the object is from the center, higher the impact of explosion will be.
    private int DamageQuantity(Collider other)
    {
        return (int)(powerAttack * ProximityOfCenter(other));
    }
    
    private float ProximityOfCenter(Collider other)
    {
        Transform otherPos = other.transform;
        float distance = Vector3.Distance(transform.position, otherPos.position);

        //depending whether the object is in the circle, distance can be negative or positive.
        //to correctly measure the proximity, we need to take this in account
        //example: for radius = 5, and distance from the center -4, 
        //the proximity is 1/5 = (5 +(-4))/5 = 0,2 ( and not 9/5 (5-(-4))/5 )
        if (distance < 0)
        {
            proximity = (myCollider.radius + distance)/myCollider.radius;
        }
        else
        {
            proximity = (myCollider.radius - distance)/myCollider.radius;
        }
        if (proximity <= 0)
        {
            proximity = 0;
        }
        return proximity;
    }

    private void ExplosionEnd()
    {
        Destroy(GetComponent<Collider>());
        Destroy(gameObject, 5f);
    }
}
