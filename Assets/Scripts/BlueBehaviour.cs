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
        Debug.Log(message: nav.isStopped);
        float dist = CalculDistance();
        if(nav.isStopped && isNotOnTrack)
        {
            Debug.Log(message: nav.isStopped);
            Vector3 pos = transform.position;
            nav.destination = new Vector3(pos.x+10f, pos.y, pos.z+10f);
            isNotOnTrack = false;
            nav.isStopped = false;
        }

        if(dist<=1)
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
        Vector3 randomPointOnCircle = Random.insideUnitSphere;
        randomPointOnCircle.Normalize();
        randomPointOnCircle *= radius;
        randomPointOnCircle += transform.position;
        return randomPointOnCircle;
    }

    private float CalculDistance()
    {
        float result = Vector3.Distance(player.position, transform.position);

        return result;
    }
}
