using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDeath : MonoBehaviour
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
        if (collision.gameObject.CompareTag("Death Area"))
        {
            
            Die();
        }
    }

    private void Die()
    {
        rb.bodyType = RigidbodyType2D.Static;
        anim.SetTrigger("Death");
    }
   
    void ResetPlayer()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
        
}
