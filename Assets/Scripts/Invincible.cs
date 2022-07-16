using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invincible : MonoBehaviour
{
    Health life;
    [SerializeField] GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        //Health related variables
        life = player.GetComponent<Health>();

        //Resets health and makes player invincible
        life.health = life.MAX_HEALTH;
        life.invincibility = true;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Destroy(other.gameObject);
        }
    }
}
