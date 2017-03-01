using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivadorSpikes : MonoBehaviour {

    public GameObject spikes;
    private Animator animatorSpikes;
    private GameObject gameController;
    private bool reinicio;

	// Use this for initialization
	void Start ()
    {
        animatorSpikes = spikes.GetComponent<Animator>();
        gameController = GameObject.FindGameObjectWithTag("GameController");
	}
    public void Update()
    {
        reinicio = gameController.GetComponent<GameController>().Muerte;
        if (reinicio)
        {
            animatorSpikes.SetInteger("Estado", 2);
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            animatorSpikes.SetInteger("Estado", 1);
            spikes.GetComponent<AudioSource>().Play();
        }
    }
    
}
