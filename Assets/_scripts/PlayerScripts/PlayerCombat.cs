using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public Animator animator;

    public Transform attackPoint1;
    public Transform attackPoint2;
    public LayerMask enemyLayers;


    public float attackRange = 0.5f;
    public int attackDamage = 40;

    public float attackRate = 2f;
    float nextAttackTime = 0f;

 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= nextAttackTime)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                attack();
                nextAttackTime = Time.time + 1f / attackRate;
            }

        }
    }

    void attack()
    {
        animator.SetTrigger("attack"); 

        Collider2D[] hitEnemies1 = Physics2D.OverlapCircleAll(attackPoint1.position, attackRange, enemyLayers);
        Collider2D[] hitEnemies2 = Physics2D.OverlapCircleAll(attackPoint2.position, attackRange, enemyLayers);


        foreach (Collider2D enemy in hitEnemies1)
        {
            enemy.GetComponent<Skeleton>().TakeDamage(attackDamage);
        }

        foreach (Collider2D enemy in hitEnemies2)
        {
            enemy.GetComponent<Skeleton>().TakeDamage(attackDamage);
        }

    }

    private void OnDrawGizmos()
    {
        if (attackPoint1 == null)
            return;
        Gizmos.DrawWireSphere(attackPoint1.position, attackRange);

        if (attackPoint2 == null)
            return;
        Gizmos.DrawWireSphere(attackPoint2.position, attackRange);
    }
}
