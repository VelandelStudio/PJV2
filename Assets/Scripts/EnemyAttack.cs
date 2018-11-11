using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour {

    private Transform player;
    private Animator animator;
    private bool canAttack = true;

    public int powerAttack;
    public float attackRange = 6f;
    public bool isAttacking = false;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        animator = GetComponent<Animator>();

        SetEnemyPower();
    }

    private void Update()
    {
        if (player)
        {
            float dist = CalculDistance();

            if (dist <= attackRange)
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

    private void DealDamage()
    {
        PlayerHealth playerHealth = player.GetComponentInParent<PlayerHealth>();

        if (playerHealth)
        {
            playerHealth.TakeDamage(powerAttack);
        }
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

    IEnumerator AttackDelayed(float time)
    {
        yield return new WaitForSeconds(time);

        canAttack = true;
    }

    private void SetEnemyPower()
    {
        powerAttack = GameManagement.instance.Level * 5;
    }
}
