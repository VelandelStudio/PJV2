using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMouvement : MonoBehaviour {

    public float speed;

    public GameObject bullet;
    public Transform bulletSpawn;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        float moveH = Input.GetAxis("Horizontal");
        float moveV = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveH, 0, moveV);

        rb.AddForce(movement * speed);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(bullet, bulletSpawn);
        }
    }
}
