using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedBullet : MonoBehaviour {


    private string type = "red";

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
        Vector3 vector = Vector3.forward;
        rb.AddForce(vector * 800);
    }
}
