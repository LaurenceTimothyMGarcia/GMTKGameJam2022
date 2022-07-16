using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMelee : MonoBehaviour
{   
    public GameObject attackArea;
    
    public bool attacking = false;
    private float timeToAttack = 0.25f;
    private float timer = 0f;
    
    void Start()
    {
        attackArea = transform.GetChild(0).gameObject;
        
    }

   void Update()
   {
        attackArea.SetActive(false);
        if(Input.GetKeyDown(KeyCode.Mouse1)){
            Attack();
        }

        //reset attack
        if(attacking){
            Debug.Log("ATTACK");
            //counts
            timer += Time.deltaTime;
            if(timer >= timeToAttack){
                //resets timer
                timer = 0;
                attacking = false;
                attackArea.SetActive(attacking);
            }
        }
   }

    private void Attack(){
        attacking = true;
        Debug.Log("Hitting");
        attackArea.SetActive(attacking);    
   }
}

