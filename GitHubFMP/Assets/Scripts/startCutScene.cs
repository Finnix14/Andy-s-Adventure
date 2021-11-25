using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startCutScene : MonoBehaviour
{
    public static bool isCutsceneOn; 
    public Animator camAim;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            
            camAim.SetBool("cutScene1", true);
            Invoke(nameof(StopCutScene), 10f);
        }

        void StopCutScene()
        {
            isCutsceneOn = false;
            camAim.SetBool("cutScene1", false);
            Destroy(this.gameObject);
        }
    }
}
