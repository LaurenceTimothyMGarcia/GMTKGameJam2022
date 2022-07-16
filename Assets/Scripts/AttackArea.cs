using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackArea : MonoBehaviour
{
   [SerializeField] private int damage = 100; 

   /// OnTriggerEnter is called when the Collider other enters the trigger.
   private void OnTriggerEnter2D(Collider2D collider)
   {
        //checks if collider has a health component
        if(collider.GetComponent<Health>() != null){
            Debug.Log("healthtrigger");
            Health health = collider.GetComponent<Health>();
            health.damage(damage);
        }
   }
}
