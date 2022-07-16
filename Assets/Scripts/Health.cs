using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    // Start is called before the first frame update
    private int health = 100;
    private int MAX_HEALTH = 100;
    
    //invincibility
    public bool invincibility = false;

    public void damage(int amount){
        if(amount < 0){
            throw new System.ArgumentOutOfRangeException("Health out of bounds!!!");
        }

        if(invincibility == false){
            Debug.Log("took damage!");
            Debug.Log(health);
            this.health -= amount;
            if(health <= 0){
                Death();
            }
        }
    }

    public void Death(){
        Debug.Log("YOU DIED  --  GAME OVER");
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

    
}
