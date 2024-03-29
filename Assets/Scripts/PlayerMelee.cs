using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMelee : MonoBehaviour
{   
    public GameObject attackArea = default;
    public bool attacking = false;
    public float timeToAttack = 0.25f;
    private float timer = 0f;
    public SpriteRenderer renderer;
    public float offset;
    private float timeBtwAttacks;
    public float startTimeBtwAttacks;

    //AudioManager bulletSound;
    //GameObject bSound;

    void Start()
    {
        //bulletSound = GetComponent<AudioManager>();

        attackArea = transform.GetChild(1).gameObject;
        attackArea.SetActive(false);
        renderer = gameObject.GetComponent<SpriteRenderer>();
    }

   void Update()
   {
        // Handles the weapon rotation
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotZ + offset);
        if (difference.x < 0)
        {
            renderer.flipX = true;
        }
        else
        {
            renderer.flipX = false;
        }

        if(Input.GetMouseButton(0))
        {
            if (!attacking && timeBtwAttacks <= 0)
            {
                timeBtwAttacks = startTimeBtwAttacks;
                Attack();
            }
        }

        if (!attacking && timeBtwAttacks > 0)
        {
            timeBtwAttacks -= Time.deltaTime;
        }
        

        //reset attack
        if(attacking){
            //counts
            renderer.enabled = false;
            timer += Time.deltaTime;
            if(timer >= timeToAttack){
                //resets timer
                timer = 0;
                attacking = false;
                attackArea.SetActive(attacking);
            }
        }
        else
        {
            renderer.enabled = true;
        }


   }

    private void Attack(){
        FindObjectOfType<AudioManager>().Play("Whip");
        attacking = true;
        attackArea.SetActive(attacking);  
   }
}

