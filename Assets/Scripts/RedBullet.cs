using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// RedBullet Class
/// Describe what bullet does when Shooted
/// </summary>
public class RedBullet : MonoBehaviour {

    public string type;
    public float force;
    public int damage = 10;
    public ParticleSystem PS_RedBulletHits;

    private Rigidbody rb;

    /// <summary>
    /// On start, we set the bullet to have no parent for no rotation
    /// </summary>
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        ApplyForce();

        transform.parent = null;
        Destroy(gameObject, 10f);
    }

    /// <summary>
    /// Dealing damage if other of player
    /// </summary>
    /// <param name="other">An Enemy</param>
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

    /// <summary>
    /// OnHitParticleSystem method
    /// Emits some particules when enemy Dies
    /// </summary>
    private void OnHitParticleSystem()
    {
        PS_RedBulletHits.transform.SetParent(null);
        PS_RedBulletHits.Play(true);
        Destroy(PS_RedBulletHits.gameObject,5f);
    }
}
