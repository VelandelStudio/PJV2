using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// OpenCell Class
/// Manage the Behavior of the door in a cell
/// </summary>
public class OpenCell : MonoBehaviour {

    public int doorHealth = 50;

    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    /// <summary>
    /// The door is shootable,
    /// Update check if the door is "alive" to launch the Door Animation
    /// </summary>
    private void Update()
    {
        if (doorHealth <= 0)
        {
            anim.SetTrigger("isActivated");

            Destroy(gameObject, 2f);
        }
    }

    /// <summary>
    /// OnTriggerEnter Unity Method
    /// Usable when DoorCell is get by an entity that deals damages.
    /// </summary>
    /// <param name="other">The entity that touch the DoorCell</param>
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<RedBullet>())
        {
            RedBullet bullet = other.GetComponent<RedBullet>();

            doorHealth -= bullet.damage;
        }
    }
}
