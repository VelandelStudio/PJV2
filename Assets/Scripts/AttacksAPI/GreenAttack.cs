using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BezierSolution;

public class GreenAttack : MonoBehaviour, IAttacks
{
    [SerializeField] private float cooldownTimer;
    [SerializeField] private List<GameObject> greenBulletList;
    [SerializeField] private GreenEnemyBezierController bezierController;

    private Queue<GameObject> greenBulletPool;

    [SerializeField] private Transform cannonEnd;

    private PlayerHealth playerHealth;
    private bool isInScope
    {
        get {     
            return Vector3.Distance(transform.position, playerHealth.transform.position) > 10f;
        }
    }
    private bool isOnCooldown;

    public int Puissance
    {
        get
        {
            return 50;
        }
        private set { }
    }

    public void DealDamage()
    {
        playerHealth.TakeDamage(Puissance);
    }

    public int SetPower(int puissance, int forceIndividu)
    {
        return puissance + forceIndividu;
    }

    // Start is called before the first frame update
    void Start()
    {
        greenBulletPool = new Queue<GameObject>(greenBulletList);
        for (int i = 0; i < greenBulletList.Count; i++)
        {
            greenBulletList[i].SetActive(false);
            greenBulletPool.Enqueue(greenBulletList[i]);
        }

        Puissance = SetPower(10, GetComponent<IEnemies>().ForceIndividu);

        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if(player)
        {
            playerHealth = player.GetComponent<PlayerHealth>();
        }

        if(!player || !playerHealth)
        {
            Debug.LogError("Le player ou son script PlayerEntity n'a pas pu être trouvé sur la scène de jeu. Corrigez svp.");
            Application.Quit(-1);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if(!isOnCooldown && other.gameObject.CompareTag("Player"))
        {
            if (isInScope)
            {
                Shoot();
            }
        }
    }

    private void Shoot()
    {
        StartCoroutine("CooldownHandler");
        BezierSpline splineInst = bezierController.CreateCustomBezierSpline(playerHealth.transform.position);
        GameObject bullet = greenBulletPool.Dequeue();
        bullet.transform.SetParent(null);
        bullet.GetComponent<BezierWalkerWithTime>().spline = splineInst;
        bullet.SetActive(true);
        greenBulletPool.Enqueue(bullet);
    }

    public void BulletEndPath(GameObject bullet)
    {
        BulletHasHit(null, bullet);
    }

    public void BulletHasHit(Collider colliderHit, GameObject bullet)
    {
        bullet.SetActive(false);
        bullet.transform.SetParent(bezierController.transform);
        bullet.GetComponent<BezierWalkerWithTime>().spline = null;
        bullet.transform.localPosition = Vector3.zero;

        if(colliderHit && colliderHit.CompareTag("Player"))
        {
            DealDamage();
        }
    }

    private IEnumerator CooldownHandler()
    {
        isOnCooldown = true;
        yield return new WaitForSeconds(cooldownTimer);
        isOnCooldown = false;
    }
}
