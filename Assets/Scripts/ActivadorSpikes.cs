using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivadorSpikes : MonoBehaviour {

    public GameObject spikes;
    private Animator animatorSpikes;

	// Use this for initialization
	void Start ()
    {
        animatorSpikes = spikes.GetComponent<Animator>();
	}
    public void OnTriggerEnter(Collider other)
    {
        animatorSpikes.SetInteger("Estado", 1);
        Debug.Log("Se Activaron!");
    }
}
