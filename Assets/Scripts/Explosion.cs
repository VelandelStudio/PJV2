using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public int powerAttack;
    private Rigidbody rb;
    private SphereCollider myCollider;
    private float proximity;

    void Start()
    {
        //SetEnemyPower();
        myCollider = GetComponent<SphereCollider>();
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        ExplosionEnd(); //As the explosion only exist for an instant, end seems to be fitting here 
    }

    public void OnTriggerEnter(Collider other)
    {
        // changes that could be reeeeaaally nice : 
        //one health script for everyone (player and enemy), one common tag 'ennemy' for all enemies
        if (other.CompareTag("RedEnemy"))
        {
            RedEnemy enemy = other.GetComponentInParent<RedEnemy>();
            enemy.TakeDamage(powerAttack * ProximityOfCenter(other), "explosion");

        }
        /*else if (other.CompareTag("BlueEnemy"))
        {
            BlueEnemy enemy = other.GetComponentInParent<BlueEnemy>();
            enemy.TakeDamage(powerAttack * ProximityOfCenter(other), "explosion");
        }*/
        else if (other.CompareTag("Player"))
        {
            PlayerHealth player = other.GetComponentInParent<PlayerHealth>();
            player.TakeDamage(powerAttack * ProximityOfCenter(other));
        }

        PushBack(other);
    }

    //this function needs to be reworked, otherwise the effect of distance from explosion doesn't work
    private void SetEnemyPower()
    {
        powerAttack = GameManagement.instance.Level * powerAttack;
    }

    //push the object away from the center of explosion, with a higher force if object is close to it.
    private void PushBack(Collider other)
    {
        Transform otherTransform = other.GetComponentInParent<Transform>();
        otherTransform.Translate(Vector3.back * ProximityOfCenter(other));
    }

    //closer the object is from the center, higher the impact of explosion will be.
    private int ProximityOfCenter(Collider other)
    {
        //if the object is really close to the center of explosion, proximity will be higher
        Transform otherPos = other.GetComponentInParent<Transform>();
        float distance = Vector3.Distance(transform.position, otherPos.position);

        //depending whether the object is in the circle, distance can be negative or positive.
        //to correctly measure the proximity, we need to take this in account
        //example: for radius = 5, and distance from the center -4, the proximity is 1 (5 +(-4)) and not 9(5-(-4))
        if (distance < 0)
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
        rb.isKinematic = true; //not sure if a rb fits an explosion tough ...

        Destroy(GetComponent<Collider>());
        Destroy(gameObject, 5f);
    }
}
