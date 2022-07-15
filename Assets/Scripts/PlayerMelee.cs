using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMelee : MonoBehaviour
{   
   private GameObject attackArea = default;

    private bool attacking = false;

    private float timeToAttack = 0.25f;
    private float timer = 0f;

    void Start()
    {
        attackArea = transform.GetChild(0).gameObject;
    }

   void Update()
   {
       if(Input.GetKeyDown(KeyCode.Space)){
            Attack();
       }

       //timer
       if(attacking)
        timer += Time.deltaTime;
        if(timer >= timeToAttack){
            timer = 0;
            attacking = false;
            attackArea.SetActive(attacking);
        }

   }

   private void Attack(){
        attacking = true;
        attackArea.SetActive(attacking);
   }
}
