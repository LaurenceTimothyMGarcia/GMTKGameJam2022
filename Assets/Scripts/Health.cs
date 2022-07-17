using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Health : MonoBehaviour
{
    // Start is called before the first frame update
    public int health;
    public int MAX_HEALTH = 100;
    public Animator animator;
    //invincibility
    public Healthbar healthBar;
    public bool invincibility = false;
    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>

    void Start()
    {
        health = MAX_HEALTH;
        healthBar.setMaxHealth(MAX_HEALTH);
    }
    void Update()
    {
        // if (Input.GetMouseButton(1))
        // {
        //     damage(1);
        // }
    }
    public void damage(int amount){
        if(amount < 0){
            throw new System.ArgumentOutOfRangeException("Health out of bounds!!!");
        }
        
        if(invincibility == false){
            //Debug.Log("took damage!");
            Debug.Log(health);
            this.health -= amount;
            StartCoroutine(TookDamage());
            healthBar.setHealth(health);
            if(health <= 0){
                Death();
            }
        }
    }

    public void Death(){
        Debug.Log("YOU DIED  --  GAME OVER");
        SceneManager.LoadScene("GameOver");
        Destroy(gameObject);
        
    }

    //one of numbers will heal 
    public void heal(int amount){
        if(amount < 0){
            throw new System.ArgumentOutOfRangeException("Health out of bounds!!!");
        }

        if(health + amount > MAX_HEALTH){
            health = MAX_HEALTH;
        }else{
            health += amount;
        }

    }
    private IEnumerator TookDamage(){
        animator.SetBool("Hurt", true);
        yield return new WaitForSeconds(0.25f);
        animator.SetBool("Hurt", false);
    }
}
