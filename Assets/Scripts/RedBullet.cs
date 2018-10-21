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
            Vector3 direction = other.transform.position - transform.position;

            RedEnemy target = other.GetComponent<RedEnemy>();
            target.GetComponent<Rigidbody>().AddForceAtPosition(direction.normalized * 500f, transform.position);

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
        Destroy(gameObject);
    }
}
