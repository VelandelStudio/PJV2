using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenCell : MonoBehaviour {

    public int doorHealth = 50;

    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (doorHealth <= 0)
        {
            anim.SetTrigger("isActivated");

            Destroy(gameObject, 2f);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<RedBullet>())
        {
            RedBullet bullet = other.GetComponent<RedBullet>();

            doorHealth -= bullet.damage;
        }
    }
}
