using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Rigidbody2D rb;

    void OnCollisionEnter2D (Collision2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            var magnitude = 250;

            Vector2 force = transform.position - other.transform.position;

            force.Normalize ();
            rb.AddForce(force * magnitude);
        }
    }
}
