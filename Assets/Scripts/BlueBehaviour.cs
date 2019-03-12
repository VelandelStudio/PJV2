using UnityEngine;
using UnityEngine.AI;
using BezierSolution;
public class BlueBehaviour : MonoBehaviour
{
    private BlueEnemy enemy;
    private NavMeshAgent nav;
    private Transform player;
    public Explosion boom;
    public int radius;
    private Vector3 startPoint;

    [SerializeField] private Transform destinationPoint;
    [SerializeField] private BezierSpline bezierSpline;

    [SerializeField] private GameObject PS_EnemyLoadExplosion;
    [SerializeField] private GameObject PS_EnemyExplosion;

    private BezierWalkerWithSpeed bezierWalker;

    public bool HasArrived = false;
    public bool chasePlayer;

    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        enemy = GetComponent<BlueEnemy>();
        bezierWalker = GetComponent<BezierWalkerWithSpeed>();
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
            if(HasArrived)
            {
                if(destinationPoint)
                {
                    Destroy(destinationPoint.gameObject);
                }
                if(bezierSpline)
                {
                    bezierSpline.transform.SetParent(null);
                    bezierWalker.enabled = true;
                }
            }
        }

        if (chasePlayer)
        {
            nav.destination = player.position;
            if(Vector3.Distance(transform.position, player.position) < 4f)
            {
                Explodes();
            }
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.transform.root.CompareTag("Player"))
        {
            if(destinationPoint)
            {
                Destroy(destinationPoint.gameObject);
            }
            if (bezierSpline)
            {
                bezierWalker.enabled = false;
                Destroy(bezierWalker);
                Destroy(bezierSpline.transform.gameObject);
            }
            PS_EnemyLoadExplosion.SetActive(true);

            Invoke("Explodes", 30);
            chasePlayer = true;
        }
    }
    public void Explodes()
    {
        CancelInvoke("Explodes");
        chasePlayer = false;
        Instantiate(boom, transform.position, transform.rotation);
        PS_EnemyExplosion.transform.SetParent(null);
        PS_EnemyExplosion.SetActive(true);
        Destroy(PS_EnemyExplosion, 10f);

        enemy.Die();
    }

    private Vector3 RandomPointOnSphere()
    {
        Vector2 randomPoint = Random.insideUnitCircle * radius;
        Vector3 randomPointOnCircle = new Vector3(transform.position.x + randomPoint.x, transform.position.y, transform.position.z + randomPoint.y);

        int i = 0;
        while (!PositionManagement.Instance.IsInsideArena(randomPointOnCircle) && i < 20)
        {
            i++;
            randomPointOnCircle = new Vector3(transform.position.x + randomPoint.x, transform.position.y, transform.position.z + randomPoint.y);
        }

        return randomPointOnCircle;
    }
}
