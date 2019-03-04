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
    public int radius = 5;
    private bool isNotOnTrack = true;

    private Vector3 startPoint;
    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        enemy = GetComponent<BlueEnemy>();
        startPoint = RandomPointOnSphere();
        nav.destination = startPoint;
    }

    // Update is called once per frame
    void Update()
    {
        if (nav)
        {
            Debug.Log(message: nav.isStopped);
            if(DistanceFromStart())
            {
                Vector3 pos = transform.position;
                nav.destination = new Vector3(pos.x+10f, pos.y, pos.z+10f);
                nav.isStopped = false;
            }
        }

        float distJoueur = CalculDistance(player.position, transform.position);
        if(distJoueur <= 1)
        {
            Explodes();
        }
    }

    private bool DistanceFromStart()
    {
        float distStart = CalculDistance(startPoint, transform.position);
        if(distStart == 0 )
        {
            return false;
        }
        return true;
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
        Vector3 randomPointOnCircle = Random.insideUnitSphere;
        randomPointOnCircle.Normalize();
        randomPointOnCircle *= radius;
        randomPointOnCircle += transform.position;
        return randomPointOnCircle;
    }

    private float CalculDistance(Vector3 a, Vector3 b)
    {
        float result = Vector3.Distance(a, b);

        return result;
    }
}
