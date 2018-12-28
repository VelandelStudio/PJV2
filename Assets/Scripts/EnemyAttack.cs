using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// EnemyAttack class,
/// Placed on ennemies to make them target and attack the player.
/// </summary>
public class EnemyAttack : MonoBehaviour {

    private Transform player;
    private Animator animator;
    private bool canAttack = true;

    public int powerAttack;
    public float attackRange = 6f;
    public bool isAttacking = false;

    /// <summary>
    /// On Awake, we locate the Player and load the enemy Animator.
    /// Then we calculate the power of the ennemies depending on the level.
    /// </summary>
    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        animator = GetComponent<Animator>();

        SetEnemyPower();
    }

    /// <summary>
    /// On Update, we try to catch the Distance between the player and the Ennemy, 
    /// If the Distance is lwer than the threshold the ennemy attacks.
    /// </summary>
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

    /// <summary>
    /// Simply tries to get the playerHealth script and deal damages to the target.
    /// </summary>
    private void DealDamage()
    {
        PlayerHealth playerHealth = player.GetComponentInParent<PlayerHealth>();

        if (playerHealth)
        {
            playerHealth.TakeDamage(powerAttack);
        }
    }

    /// <summary>
    /// Launched on Update,
    /// Synchronise the animator while the ennemy is attacking.
    /// We also play with a bool called canAttack which acts as a cooldown.
    /// </summary>
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

    /// <summary>
    /// Used On Awake, 
    /// Set the power of the ennemy depending on the level.
    /// </summary>
    private void SetEnemyPower()
    {
        powerAttack = GameManagement.instance.Level * 5;
    }
}
