using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Skeleton : MonoBehaviour
{
    public Animator animator;
    public int maxHealth = 100;
    int currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        animator.SetTrigger("hit");

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("Enemy died");
        animator.SetBool("die", true);
        GetComponent<Collider2D>().enabled = false;
        // Menjalankan fungsi untuk menghilangkan game object dengan delay 2 detik
        StartCoroutine(DestroyAfterDelay(2.0f));
    }

    IEnumerator DestroyAfterDelay(float delay)
    {
        // Tunggu selama 'delay' detik sebelum menghilangkan game object
        yield return new WaitForSeconds(delay);
        // Menghilangkan game object
        Destroy(gameObject);
    }
}
