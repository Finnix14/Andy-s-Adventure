using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickyRope : MonoBehaviour
{
    public Rigidbody2D rb;
    private HingeJoint2D hj;

    public bool attatched = false;
    public Transform attatchedTo;
    private GameObject disregard;

    private void Awake()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        hj = gameObject.GetComponent<HingeJoint2D>();
    }



    private void OnTriggerEnter2D(Collider2D col)
    {
        if (!attatched)
        {
            if (col.gameObject.tag == "Rope")
            {
                if (attatchedTo != col.gameObject.transform.parent)
                {
                    if (disregard == null || col.gameObject.transform.parent.gameObject != disregard)
                    {
                        Attach(col.gameObject.GetComponent<Rigidbody2D>());
                    }
                }
            }
        }
    }



    public void Attach(Rigidbody2D ropeBone)
    {
        ropeBone.gameObject.GetComponent<RopeSegment>().isPlayerAttached = true;
        hj.connectedBody = ropeBone;
        hj.enabled = true;
        attatched = true;
        attatchedTo = ropeBone.gameObject.transform.parent;
    }
}