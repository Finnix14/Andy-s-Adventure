using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathAI : MonoBehaviour
{
    Rigidbody2D rb;
    Animator anim;
    AudioSource explosion;

    private void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        explosion = GetComponent<AudioSource>();
    }



    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("EnemyAI"))
        { 
            Die();
        }
    }

    private void Die()
    {
        rb.bodyType = RigidbodyType2D.Dynamic;
        anim.SetTrigger("DeathAI");
    }


}
