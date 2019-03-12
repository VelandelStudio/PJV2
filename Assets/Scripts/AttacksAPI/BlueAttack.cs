using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BlueAttack : MonoBehaviour, IAttacks
{
    private BlueBehaviour movement;
    private NavMeshAgent nav;
    private Transform player;
    // Start is called before the first frame update
    public int Puissance { get; protected set; }
    public int SetPower(int puissance, int forceIndividu){return Puissance;}
    public void DealDamage(){}
    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        movement = GetComponent<BlueBehaviour>();
    }

    // Update is called once per frame
    void Update()
    {
        if (movement.chasePlayer)
        {
            nav.destination = player.position;
            if(Vector3.Distance(transform.position, player.position) < 4f)
            {
                movement.Explodes();
            }
        }
        
    }
}
