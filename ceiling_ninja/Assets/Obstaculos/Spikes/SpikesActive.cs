using UnityEngine;
using System.Collections;

public class SpikesActive : MonoBehaviour {

    private Animator animSpikes;

    private void Start()
    {
        animSpikes = GetComponent<Animator>();
        animSpikes.SetInteger("Estado", 0);
        
    }

    // Update is called once per frame
    void Update ()
    {
        if (animSpikes.GetCurrentAnimatorStateInfo(0).IsName("Default"))

         { 
            if (Input.GetKey(KeyCode.U))
            {
                animSpikes.SetInteger("Estado", 1);
            }  
        }
        else
        {
            if (animSpikes.GetCurrentAnimatorStateInfo(0).IsName("SpikesOff"))
            {
                if (Input.GetKey(KeyCode.U))
                {
                    animSpikes.SetInteger("Estado", 3);
                }
            }
            else
            {
                if (animSpikes.GetCurrentAnimatorStateInfo(0).IsName("SpikesOn"))
                {
                    if (Input.GetKey(KeyCode.D))
                    {
                        animSpikes.SetInteger("Estado", 2);
                    }
                }
            }
        }
            
    }
}

