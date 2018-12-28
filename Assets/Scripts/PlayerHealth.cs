using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// PlayerHealth Class
/// Manage the life and death of the playerHealth
/// </summary>
public class PlayerHealth : MonoBehaviour {

    private int health = 100;
    public int Health
    {
        get { return health; }
        set { health = value; }
    }

    private void Update()
    {
        if (IsDead())
        {
            Debug.Log("T'es àso");
        }
    }

    /// <summary>
    /// TakeDamage method
    /// Set the life of the player
    /// </summary>
    /// <param name="damage">The number of damage that takes the player</param>
    public void TakeDamage(int damage)
    {
        health -= damage;
    }

    /// <summary>
    /// IsDead method
    /// Set if the player is alive or dead
    /// </summary>
    /// <returns>boolean</returns>
    private bool IsDead()
    {
        if (health <= 0)
        {
            return true;
        }

        return false;
    } 
}
