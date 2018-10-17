using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedBullet : MonoBehaviour {

    private string type = "red";
    public float force;

    int _damage = 10;
    int damage
    {
        get
        {
            return _damage;
        }
    }

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
        if (type == "red")
        {
            Debug.Log("Touch Aso");
        }

        Destroy(gameObject);
    }

    private void ApplyForce()
    {
        rb.AddForce(transform.forward * force);
    }
}
