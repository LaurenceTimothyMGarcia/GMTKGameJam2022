using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackArea : MonoBehaviour
{
   private int damage = 3; 

   /// OnTriggerEnter is called when the Collider other enters the trigger.
   void OnTriggerEnter2D(Collider2D collider)
   {
       if(collider.GetComponent<Health>() != null){
        Health health = collider.GetComponent<Health>();
        health.damage(damage);
       }
   }
}
