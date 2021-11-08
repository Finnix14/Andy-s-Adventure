using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerController : MonoBehaviour
{
    //Start() variables
    private Rigidbody2D rb;
    private Animator anim;
    private Collider2D coll;

    //FSM
    private enum State { Idle, Running, Jumping, Falling, Hurt }
    private State state = State.Idle;

    //Inspector variables
    [SerializeField] private LayerMask ground;
    [SerializeField] private float speed = 5f;
    [SerializeField] private float jumpForce = 10f;
    [SerializeField] private int cherries = 0;
    [SerializeField] private Text cherryText;
    [SerializeField] private float hurtForce = 10f;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        coll = GetComponent<Collider2D>();
    }
    private void Update()
    {
        if (state != State.Hurt)
        {
            Movement();
        }
        AnimationState();
        anim.SetInteger("state", (int)state); //sets animation based on Enumerator state
    }
    private void OnTriggerEnter2D(Collider2D collision) //Trigger for Collectables
    {
        if (collision.tag == "Collectable")
        {
            Destroy(collision.gameObject); //Cherry destroy
            cherries += 1;
            cherryText.text = cherries.ToString(); //Converting number to string
        }
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        EnemyAI possum = other.gameObject.GetComponent<EnemyAI>();
        
        if (other.gameObject.tag == "Enemy")
        {
            if (state == State.Falling)
            {
                Destroy(possum.gameObject);
                Jump();
            }
            else
            {
                state = State.Hurt;
                if (other.gameObject.transform.position.x > transform.position.x)
                {
                    //Enemy is to my right therefore should be damaged and move left
                    rb.velocity = new Vector2(-hurtForce, rb.velocity.y);
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
        if (Input.GetButtonDown("Jump") && coll.IsTouchingLayers())
        {
            Jump();
        }
    }
    private void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        state = State.Jumping;
    }
    private void AnimationState()
    {
        if (state == State.Jumping)
        {
            if (rb.velocity.y < .1f)
            {
                state = State.Falling;
            }
        }
        else if (state == State.Falling)
        {
            if (coll.IsTouchingLayers(ground))
            {
                state = State.Idle;
            }
        }
        else if (state == State.Hurt)
        {
            if (Mathf.Abs(rb.velocity.x) < .1f)
            {
                state = State.Idle;
            }
        }

        else if (Mathf.Abs(rb.velocity.x) > 2f)
        {
            //Moving
            state = State.Running;
        }
        else
        {
            state = State.Idle;
        }
    }
    public void JumpedOn()
    {
        anim.SetTrigger("Death");
    }

    private void Death()
    {
        Destroy(this.gameObject);
    }

}



