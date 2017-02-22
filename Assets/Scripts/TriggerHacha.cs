using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerHacha : MonoBehaviour {

    public GameObject objHacha;
    private Animator animHacha;
    
    public GameController script;
    public GameObject gameController;
    public int velocidadClip = 1;

    // Use this for initialization
    void Start()
    {
        //Velocidad del Hacha
        animHacha = objHacha.GetComponent<Animator>();
        animHacha.speed = 0;
        script = gameController.GetComponent <GameController> ();
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            animHacha.speed = velocidadClip;
            animHacha.Play("AxeAction",0);
            //animHacha.speed = 1;
        }
    }
    // Update is called once per frame
    void Update ()
    {
		if (script.Muerte ==true)
        {
            animHacha.Play("AxeAction", 0, 0.0f);
            animHacha.speed = 0;
        }
	}
}
