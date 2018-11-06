using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedBullet : MonoBehaviour {

    public string type;
    public float force;
    public int damage = 10;
    public ParticleSystem PS_RedBulletHits;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        ApplyForce();

        transform.parent = null;
        Destroy(gameObject, 10f);
    }

    private void OnTriggerEnter(Collider other)
    {

        if(other.GetComponent<RedBullet>() || other.CompareTag("Player"))
        {
            return;
        }

        OnHitParticleSystem();

        if (other.GetComponent<RedEnemy>())
        {
            RedEnemy target = other.GetComponent<RedEnemy>();
            target.TakeDamage(damage, this);
        }

        Destroy(gameObject);
    }

    private void ApplyForce()
    {
        rb.AddForce(transform.forward * force);
    }

    private void OnHitParticleSystem()
    {
        PS_RedBulletHits.transform.SetParent(null);
        PS_RedBulletHits.Play(true);
        Destroy(PS_RedBulletHits.gameObject,5f);
    }
}
