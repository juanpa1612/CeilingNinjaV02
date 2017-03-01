using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalJuego : MonoBehaviour {


    private MovimientoPersonaje scriptNinja;
    private GameObject ninja;
    public bool gano;
    public Vector3 velocidadFinal;
    private Vector3 detenido;
    
    // Use this for initialization
	void Start ()
    {
        ninja = GameObject.FindGameObjectWithTag("Player");
        scriptNinja = ninja.GetComponent<MovimientoPersonaje>();
        velocidadFinal = new Vector3(0, 0, 100);
        gano = false;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (gano==true)
        { 
           if (scriptNinja.movimiento.z >=0)
            {
                //ninja.GetComponent<Rigidbody>().velocity = velocidadFinal;
                scriptNinja.movimiento -= velocidadFinal * Time.deltaTime;
            }
           if (scriptNinja.movimiento.z<=25)
            {
                detenido = new Vector3 (0,0,0);
            }
           if (scriptNinja.movimiento.z < 500)
            {
                ninja.GetComponent<Animator>().SetBool("Gano", true);               
                scriptNinja.Inicio();
                ninja.GetComponent<Rigidbody>().velocity = detenido;
            }
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            gano = true;           
        }
    }
}
