using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackArea : MonoBehaviour
{
   private int damage = 5; 

   /// OnTriggerEnter is called when the Collider other enters the trigger.
   private void OnTriggerEnter2D(Collider2D collider)
   {
        //checks if collider has a health component
        if(collider.GetComponent<Health>() != null ){
            Debug.Log("health trigger");
            
            Health health = collider.GetComponent<Health>();
            Debug.Log(health);
            health.damage(damage);
            
        }
   }
}
