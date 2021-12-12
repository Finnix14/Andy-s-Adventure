using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class PlayerController : MonoBehaviour
{
    //Start() variables
    private Rigidbody2D rb;
    private Animator anim;
    private Collider2D coll;






    //FSM
    private enum State { idle, run, jump, fall, hurt, crouch, Death, climb}
    private State state = State.idle;





    //Inspector variables
    [SerializeField] private LayerMask Ground;
    [SerializeField] private float speed = 5f;
    [SerializeField] private float jumpForce = 10f;
    [SerializeField] private int cherries = 0;
    [SerializeField] private Text cherryText;
    [SerializeField] private float hurtForce = 10f;
    [SerializeField] private AudioSource cherry;
    [SerializeField] private AudioSource walking;
    [SerializeField] private AudioSource jumping;
    [SerializeField] private AudioSource hurt;
    [SerializeField] private AudioSource powerup;
    [SerializeField] private AudioSource speedup;
    [SerializeField] private int health;
    [SerializeField] private Text healthAmount;

    
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        coll = GetComponent<Collider2D>();
        healthAmount.text = health.ToString();
 


    }
    private void Update()
    {

        if (state != State.hurt)
        {
            Movement();
        }
        AnimationState();
        anim.SetInteger("State", (int)state); //sets animation based on Enumerator state
    }
    private void OnTriggerEnter2D(Collider2D collision) //Trigger for Collectables
    {
        if (collision.tag == "Collectable")
        {
            cherry.Play();
            Destroy(collision.gameObject); //Cherry destroy
            cherries += 1;
            cherryText.text = cherries.ToString(); //Converting number to string
        }

        if (collision.tag == "powerup")
        {
            powerup.Play();
            Destroy(collision.gameObject);
            jumpForce = 18f;
            GetComponent<SpriteRenderer>().color = Color.red;
            StartCoroutine(ResetPower());
        }

        if (collision.tag == "speedup")
        {
            speedup.Play();
            Destroy(collision.gameObject);
            speed = 7.5f;
            GetComponent<SpriteRenderer>().color = Color.yellow;
            StartCoroutine(ResetSpeed());
        }

        {
            if (collision.gameObject.tag == "Spikes")
            {
                hurt.Play();
                state = State.Death;
                Destroy(collision.gameObject);
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }


        }

    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        EnemyAI Enemy = other.gameObject.GetComponent<EnemyAI>();

        
        if (other.gameObject.tag == "Enemy")
        {

            EnemyAI eagle = other.gameObject.GetComponent<EnemyAI>();
            EnemyAI possum = other.gameObject.GetComponent<EnemyAI>();

            if (state == State.fall)
            {
                hurt.Play();
                eagle.JumpedOn();
                possum.JumpedOn();
                Jump();
            }
            else
            {
                hurt.Play(); // Deals with health and Updates UI if health is too low
                state = State.hurt;
                health -= 25;
                healthAmount.text = health.ToString();
                if (health <= 0)
                {
                    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                }

                if (other.gameObject.transform.position.x > transform.position.x)
                {
                    //Enemy is to my right therefore should be damaged and move left
                    rb.velocity = new Vector2(-hurtForce, rb.velocity.y);
                }
                if (other.gameObject.tag == "EnemyAI")
                {
                    if (state == State.fall)
                    {
                        hurt.Play();
                        eagle.JumpedOn();
                        possum.JumpedOn();
                        Jump();
                    }
                    else
                    {
                        hurt.Play(); // Deals with health and Updates UI if health is too low
                        state = State.hurt;
                        health -= 25;
                        healthAmount.text = health.ToString();
                        if (health <= 0)
                        {
                            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                        }
                         else
                {
                    //Enemy is to my left therefore i Should be damaged and move right
                    rb.velocity = new Vector2(hurtForce, rb.velocity.y);
                }
                    }

                }
                else
                {
                    //Enemy is to my left therefore i Should be damaged and move right
                    rb.velocity = new Vector2(hurtForce, rb.velocity.y);
                }
                
            }
          
        }
    }
    private void Movement()
    {
        float hDirection = Input.GetAxis("Horizontal");

        //Moving left
        if (hDirection < 0)
        {
            rb.velocity = new Vector2(-speed, rb.velocity.y);
            transform.localScale = new Vector2(-1, 1);
        }
        //Moving right
        else if (hDirection > 0)
        {
            rb.velocity = new Vector2(speed, rb.velocity.y);
            transform.localScale = new Vector2(1, 1);
        }

        //Jumping
        if (Input.GetButtonDown("Jump") && coll.IsTouchingLayers(Ground))
        {
            jumping.Play();
            Jump();

        }

    }

    private void Jump()
    {
        
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        state = State.jump;
    }
    private void AnimationState()
    {
        
        if (state == State.jump)
        {
            if (rb.velocity.y < .1f)
            {
                state = State.fall;
            }
        }
        else if (state == State.fall)
        {
            if (coll.IsTouchingLayers(Ground))
            {
                state = State.idle;
            }
        }
        else if (state == State.hurt)
        {
            if (Mathf.Abs(rb.velocity.x) < .1f)
            {
                state = State.idle;
            }
        }

        else if (Mathf.Abs(rb.velocity.x) > 2f)
        {
            //Moving
            state = State.run;
        }
        else
        {
            state = State.idle;
        }
    }

    private void Footstep()
    {
        walking.Play();
    }

    private IEnumerator ResetPower()
    {
        yield return new WaitForSeconds(7);
        jumpForce = 11f;
        GetComponent<SpriteRenderer>().color = Color.white;
    }
    private IEnumerator ResetSpeed()
    {
        yield return new WaitForSeconds(7);
        speed = 6f;
        GetComponent<SpriteRenderer>().color = Color.white;
    }



}