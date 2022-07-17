using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

    public float speed;
    public float lifeTime;
    public float distance;
    public int damage;
    public bool isGrenade;
    public bool pierce;
    public bool canStun;
    public LayerMask whatIsSolid;
    public GameObject projectile;

    public GameObject destroyEffect;

    private void Start() {
        Invoke("DestroyProjectile", lifeTime);
    }

    private void Update() {
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.up, distance, whatIsSolid);

        if (hitInfo.collider != null) {
            if (hitInfo.collider.CompareTag("Enemy")) 
            {
                hitInfo.collider.GetComponent<EnemyHealth>().TakeDamage(damage);
                if (canStun)
                {
                    hitInfo.collider.GetComponent<EnemyBehavior>().isStunned = true;
                }
            }

            if (!pierce || hitInfo.collider.CompareTag("Ground"))
            {
                DestroyProjectile();
            }
        }

        transform.Translate(Vector2.up * speed * Time.deltaTime);
    }

    void DestroyProjectile() {
        //Instantiate(destroyEffect, transform.position, Quaternion.identity);
        if (isGrenade)
        {
            Instantiate(projectile, transform.position, transform.rotation);
            //have it explode here
        }

        Destroy(gameObject);
    }
}