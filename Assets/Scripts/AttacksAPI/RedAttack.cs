using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedAttack : MonoBehaviour, IAttacks
{
    public int Puissance{ get; protected set }

    public void DealDamage()
    {
        PlayerEntity playerHealth = player.GetComponentInParent<PlayerHealth>();

        if (playerHealth)
        {
            playerHealth.TakeDamage(powerAttack);
        }
    }

    public void SetPower(int puissance, int forceIndividu)
    {
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
