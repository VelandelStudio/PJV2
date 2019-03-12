using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedAttack : MonoBehaviour, IAttacks
{
    private Transform player;
    public int Puissance{ get; protected set; }
    private RedEnemyStat enemy;
    private Animator animator;
    public bool isAttacking = false;
    private bool canAttack = true;

    public void DealDamage()
    {
        PlayerEntity playerHealth = player.GetComponentInParent<PlayerEntity>();

        if (playerHealth)
        {
            playerHealth.Takedamage(Puissance, playerHealth.Type);
        }
    }

    public int SetPower(int puissance, int forceIndividu)
    {
        return puissance + forceIndividu;
    }

    // Start is called before the first frame update
    void Start()
    {
        enemy = GetComponent<RedEnemyStat>();
        animator = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        Puissance = SetPower(Puissance, enemy.ForceIndividu);
    }

    // Update is called once per frame
    void Update()
    {
        if (player)
        {
            float dist = CalculDistance();

            if (dist <= enemy.DetectionField)
            {
                Attacking();
            }
            else
            {
                animator.SetBool("isAttacking", false);
                isAttacking = false;
            }
        }

    }

    private float CalculDistance()
    {
        float result = Vector3.Distance(player.position, transform.position);

        return result;
    }

    private void Attacking()
    {
        animator.SetBool("isAttacking", true);
        isAttacking = true;

        AnimatorStateInfo animationStateInfo = animator.GetCurrentAnimatorStateInfo(0);

        if (animationStateInfo.IsName("AttackEnemy"))
        {
            float animTime = animationStateInfo.length;

            if (canAttack)
            {
                canAttack = false;

                DealDamage();
                StartCoroutine(AttackDelayed(animTime));
            }
        }
    }

    /// <summary>
    /// Delay the cooldown of the next attack.
    /// </summary>
    /// <param name="time"></param>
    /// <returns></returns>
    IEnumerator AttackDelayed(float time)
    {
        yield return new WaitForSeconds(time);

        canAttack = true;
    }
}
