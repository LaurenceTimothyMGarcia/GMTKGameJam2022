using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForcePush : MonoBehaviour
{
    public float speed;
    public float lifeTime;
    public float distance;
    public float forceAmount;
    public int damage;
    public bool pierce;
    public LayerMask whatIsSolid;
    public GameObject projectile;

    AudioManager[] forceSound;

    public GameObject destroyEffect;

    //AudioManager bulletSound;
    //GameObject bSound;

    private void Start() {
        //bulletSound = GetComponent<AudioManager>();
        forceSound = FindObjectsOfType<AudioManager>();
        for (int i = 0; i < forceSound.Length; i++)
        {
            if (forceSound[i].Play("ForcePush"))
            {
                forceSound[i].Play("ForcePush");
            }
        }

        Invoke("DestroyProjectile", lifeTime);
    }

    private void Update() {
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.up, distance, whatIsSolid);

        if (hitInfo.collider != null) {
            if (hitInfo.collider.CompareTag("Enemy")) 
            {
                hitInfo.rigidbody.AddForce(new Vector3(forceAmount, forceAmount, forceAmount), ForceMode2D.Impulse);
            }

            if (!pierce || hitInfo.collider.CompareTag("Ground"))
            {
                DestroyProjectile();
            }
        }

        transform.Translate(Vector2.up * speed * Time.deltaTime);
    }

    void DestroyProjectile() 
    {
        Destroy(gameObject);
    }
}
