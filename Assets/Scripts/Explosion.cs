using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Explosion : MonoBehaviour
{
    public int powerAttack;
    private SphereCollider myCollider;
    private float proximity;

    void Start()
    {
        myCollider = GetComponent<SphereCollider>();
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("RedEnemy"))
        {
            RedEnemy enemy = other.GetComponentInParent<RedEnemy>();
            enemy.TakeDamage(DamageQuantity(other), "explosion");

        }
        if (other.CompareTag("BlueEnemy"))
        {
            BlueEnemy enemy = other.GetComponentInParent<BlueEnemy>();
            enemy.TakeDamage(DamageQuantity(other), "explosion");
        }
        if (other.CompareTag("Player"))
        {
            PlayerHealth player = other.GetComponentInParent<PlayerHealth>();
            player.TakeDamage(DamageQuantity(other));
        }

        PushBack(other);
        ExplosionEnd();
    }

    //push the object away from the center of explosion, with a higher force if object is close to it.
    private void PushBack(Collider other)
    {
        CharacterController controller = other.transform.root.GetComponent<CharacterController>();
        if (controller)
        { 
            controller.enabled = false;
            StartCoroutine(EndPushBack(controller));
        }

        Rigidbody rb1 = other.GetComponentInParent<Rigidbody>();
        Debug.Log(powerAttack);
        rb1.AddForce(transform.forward * powerAttack, ForceMode.Impulse);
    }

    private IEnumerator EndPushBack(CharacterController comp)
    {
        yield return new WaitForSeconds(0.5f);
        comp.enabled = true;
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
