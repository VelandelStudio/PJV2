using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BlueBehaviour : MonoBehaviour
{
    private BlueEnemy enemy;
    private NavMeshAgent nav;
    private Transform player;
    public Explosion boom;
    public int radius;
    private Vector3 startPoint;

    [SerializeField] private Transform destinationPoint;
    public bool HasArrived = false;

    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        enemy = GetComponent<BlueEnemy>();
        destinationPoint.SetParent(null);
        startPoint = RandomPointOnSphere();
        nav.SetDestination(startPoint);
        destinationPoint.position = startPoint;
    }

    // Update is called once per frame
    void Update()
    {
        if (nav)
        {
            //Debug.Log(message: nav.isStopped);
            if(HasArrived)

            {
                Debug.Log("Je suis arrivée");
                /*Vector3 pos = transform.position;
                nav.destination = new Vector3(pos.x+10f, pos.y, pos.z+10f);
                nav.isStopped = false;*/
            }
        }

        float distJoueur = Vector3.Distance(player.position, transform.position);
        if(distJoueur <= 1)
        {
            Explodes();
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            Invoke("Explodes", 30);
            nav.destination = player.position;
        }
    }
    public void Explodes ()
    {
        Instantiate(boom, transform.position, transform.rotation);
        enemy.BeKilled();

    }
    private Vector3 RandomPointOnSphere()
    {
        Vector2 randomPoint = Random.insideUnitCircle * radius;
        Vector3 randomPointOnCircle = new Vector3(transform.position.x + randomPoint.x, transform.position.y, transform.position.z + randomPoint.y);
        return randomPointOnCircle;
    }
}
