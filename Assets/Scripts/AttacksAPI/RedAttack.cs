using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedAttack : MonoBehaviour, IAttacks
{
    private Transform player;
    public int Puissance{ get; protected set; }

    public void DealDamage()
    {
        PlayerEntity playerHealth = player.GetComponentInParent<PlayerEntity>();

        if (playerHealth)
        {
            playerHealth.Takedamage();
        }
    }

    public void SetPower(int puissance, int forceIndividu)
    {
        puissance = puissance + forceIndividu;
    }

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        SetPower(Puissance, );
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
