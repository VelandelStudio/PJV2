using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    public void TakeDamage(int damage)
    {
        health -= damage;
    }

    private bool IsDead()
    {
        if (health <= 0)
        {
            return true;
        }

        return false;
    } 
}
