using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int setHealth;
    public int currentHealth;
    public static int enemyScore;

    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = setHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHealth <= 0)
        {
            enemyScore += 1000;

            DestroyEnemy();
        }
    }

    public void TakeDamage(int damage)
    {
        //Also input animation here
        currentHealth -= damage;
        
        StartCoroutine(Damage());

    }

    void DestroyEnemy()
    {
        Destroy(gameObject);
        //Stopwatch.score += 1000;
    }
    private IEnumerator Damage()
    {
        animator.SetBool("isHit", true);
        yield return new WaitForSeconds(0.05f);
        animator.SetBool("isHit", false);
    }
}
