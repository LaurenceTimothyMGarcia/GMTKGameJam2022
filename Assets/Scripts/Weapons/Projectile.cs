using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

    public float speed;
    public float lifeTime;
    public float distance;
    public int damage;
    public bool pierce;
    public bool canStun;
    public LayerMask whatIsSolid;
    public GameObject projectile;

    AudioManager bulletSound;
    GameObject bSound;

    public bool isPistol;
    public bool isMachine;
    public bool isSnipe;
    public bool isWhip;
    public bool isForce;
    public bool isLaser;
    public bool isPie;
    public bool isGrenade;

    public GameObject destroyEffect;

    private void Start() {
        bulletSound = GetComponent<AudioManager>();
        PlaySound();

        Invoke("DestroyProjectile", lifeTime);
    }

    private void Update() {
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.up, distance, whatIsSolid);

        if (hitInfo.collider != null) {
            if (hitInfo.collider.CompareTag("Enemy")) 
            {
                hitInfo.collider.GetComponent<EnemyHealth>().TakeDamage(damage);
                if (canStun && !hitInfo.collider.GetComponent<EnemyBehavior>().isStunned)
                {
                    hitInfo.collider.GetComponent<EnemyBehavior>().BecomeStunned();
                }
            }

            if (isPie)
            {
                bulletSound.Play("PieInFace");
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

    void PlaySound()
    {
        if (isPistol)
        {
            bulletSound.Play("Pistol");
        }

        if (isMachine)
        {
            bulletSound.Play("MachineGun");
        }

        if (isSnipe)
        {
            bulletSound.Play("Sniper");
        }

        if (isWhip)
        {
            bulletSound.Play("Whip");
        }

        if (isGrenade)
        {
            bulletSound.Play("Grenade");
        }

        if (isForce)
        {
            bulletSound.Play("ForcePush");
        }

        if (isLaser)
        {
            bulletSound.Play("LaserGun");
        }
    }
}