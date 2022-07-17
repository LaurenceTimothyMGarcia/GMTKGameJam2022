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

    private AudioManager[] bulletSound;

    //AudioManager bulletSound;
    //public GameObject bSound;

    public bool isPistol;
    public bool isMachine;
    public bool isSnipe;
    public bool isWhip;
    public bool isForce;
    public bool isLaser;
    public bool isPie;
    public bool isGrenade;
    public bool isExplode;

    public GameObject destroyEffect;

    private void Awake()
    {
        bulletSound = FindObjectsOfType<AudioManager>();
    }

    private void Start() {
        //bulletSound = GetComponent<AudioManager>();
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
                for (int i = 0; i < bulletSound.Length; i++)
                {
                    if (bulletSound[i].Play("PieInFace"))
                    {
                        bulletSound[i].Play("PieInFace");
                    }
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

    void PlaySound()
    {
        if (isPistol)
        {
            //FindObjectOfType<AudioManager>().Play("Pistol");
            for (int i = 0; i < bulletSound.Length; i++)
            {
                if (bulletSound[i].Play("Pistol"))
                {
                    bulletSound[i].Play("Pistol");
                }
            }
            
        }

        if (isMachine)
        {
            //FindObjectOfType<AudioManager>().Play("MachineGun");
            for (int i = 0; i < bulletSound.Length; i++)
            {
                if (bulletSound[i].Play("MachineGun"))
                {
                    bulletSound[i].Play("MachineGun");
                }
            }
        }

        if (isSnipe)
        {
            //FindObjectOfType<AudioManager>().Play("Sniper");
            for (int i = 0; i < bulletSound.Length; i++)
            {
                if (bulletSound[i].Play("Sniper"))
                {
                    bulletSound[i].Play("Sniper");
                }
            }
        }

        if (isWhip)
        {
            //FindObjectOfType<AudioManager>().Play("Whip");
            for (int i = 0; i < bulletSound.Length; i++)
            {
                if (bulletSound[i].Play("Whip"))
                {
                    bulletSound[i].Play("Whip");
                }
            }
        }

        if (isGrenade)
        {
            //FindObjectOfType<AudioManager>().Play("Grenade");
            for (int i = 0; i < bulletSound.Length; i++)
            {
                if (bulletSound[i].Play("Grenade"))
                {
                    bulletSound[i].Play("Grenade");
                }
            }
        }

        if (isForce)
        {
            //FindObjectOfType<AudioManager>().Play("ForcePush");
            for (int i = 0; i < bulletSound.Length; i++)
            {
                if (bulletSound[i].Play("ForcePush"))
                {
                    bulletSound[i].Play("ForcePush");
                }
            }
        }

        if (isLaser)
        {
            //FindObjectOfType<AudioManager>().Play("LaserGun");
            for (int i = 0; i < bulletSound.Length; i++)
            {
                if (bulletSound[i].Play("LaserGun"))
                {
                    bulletSound[i].Play("LaserGun");
                }
            }
        }

        if (isExplode)
        {
            //FindObjectOfType<AudioManager>().Play("Explode");
            for (int i = 0; i < bulletSound.Length; i++)
            {
                if (bulletSound[i].Play("Explode"))
                {
                    bulletSound[i].Play("Explode");
                }
            }
        }
    }
}