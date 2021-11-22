using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyAIFollow : MonoBehaviour
{

    public Transform target;
    
    public float speed = 200;
    public float nextWayPointDistance = 3f;


    Path path;
    int currentWaypoint = 0;
    bool reachedEndofPath = false;

    Seeker seeker;
    Rigidbody2D rb;
    
    private Animator anim;
    protected AudioSource explosion;



    private void Start()
    {
        seeker = GetComponent<Seeker>();
        anim = GetComponent<Animator>();
        explosion = GetComponent<AudioSource>();

        seeker.StartPath(rb.position, target.position, OnPathComplete);

    }

    void OnPathComplete(Path p)
    {
        if (!p.error)
        {
            path = p;
            currentWaypoint = 0;
        }
    }

    void FixedUpdate()
    {
        if (path == null)
            return;

        if(currentWaypoint >= path.vectorPath.Count)
        {
            reachedEndofPath = true;
            return;
        }
        else
        {
            reachedEndofPath = false;
        }

        Vector2 direction = ((Vector2)path.vectorPath[currentWaypoint] - rb.position).normalized;
        Vector2 force = direction * speed * Time.deltaTime;

        rb.AddForce(force);

        float distance = Vector2.Distance(rb.position, path.vectorPath[currentWaypoint]);

        if(distance < nextWayPointDistance)
        {
            currentWaypoint++;
        }
    }




    public void JumpedOn()
    {
        anim.SetTrigger("Death");
        explosion.Play();
    }


    private void Death()
    {
        Destroy(this.gameObject);
    }

}

