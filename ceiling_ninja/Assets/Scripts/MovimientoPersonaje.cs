using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoPersonaje : MonoBehaviour {



	private Animator animator;
	public float velocity = 400;
	private Vector3 movimiento;
	private int lugar;

    //Obstaculos
    public const string OBSTACULO = "obstaculo";
    public float velocidad = 2;
    private bool murio;
    Animator animacion;

    void Awake () 
	{
		lugar = 0;
		animator = GetComponent<Animator> ();
		Correr ();
		movimiento = new Vector3 (0, 0, velocity);

	}

	void Start()
	{
        //Obstaculos
        murio = false;
        animacion = this.gameObject.GetComponent<Animator>();
    }

	void Update () 
	{
		GetComponent<Rigidbody> ().velocity = movimiento * Time.deltaTime;

		if (Input.GetKeyDown ("space")) {
			Salto ();
		}

		if (Input.GetKeyDown ("w")) {
			lugar = 2;
			Salto ();

		}

		if (Input.GetKeyDown ("d")) {
			lugar = 3;
			Salto ();
		}

		if (Input.GetKeyDown ("a")) {
			lugar = 1;
			Salto ();

		}

		if (Input.GetKeyDown ("s")) {
			lugar = 0;
			Salto ();
		}

		if (Input.GetKeyDown ("g")) {
			Muerte ();
		}
	}

    //Obstaculos
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Inicio");
        if (other.gameObject.transform.tag.Equals("obstaculo") && murio == false)
        {
            Debug.Log("Muerte");
            Muerte();
            murio = true;

        }
    }

    public void Salto()
	{
		animator.SetInteger ("Salto", 1);
	}

	public void FinalSalto()
	{
		animator.SetInteger ("Salto", 0);
	}

	public void Cambio()
	{
		switch (lugar)
		{
		case 0:
			Correr();
			break;

		case 1:
			CorrerIzquierda();
			break;

		case 2:
			CorrerTecho();
			break;

		case 3:
			CorrerDerecha();
			break;

		default:
			Correr();
			break;
		}
	}

	public void Muerte()
	{
		movimiento = Vector3.zero;
		animator.SetTrigger ("Death");
	}


	public void CorrerDerecha()
	{
		float z = transform.position.z;
		float x = 1.3f;
		float y = 2;
		Vector3 pared = new Vector3(x,y,z);
		Quaternion rotacion = Quaternion.Euler(0, 0, 90);
		transform.position = pared;
		transform.rotation = rotacion;
	}

	public void CorrerIzquierda()
	{
		float z = transform.position.z;
		float x = -1.3f;
		float y = 2;
		Vector3 pared = new Vector3(x,y,z);
		Quaternion rotacion = Quaternion.Euler(0, 0, -90);
		transform.position = pared;
		transform.rotation = rotacion;
	}

	public void CorrerTecho()
	{
		float z = transform.position.z;
		float x = 0;
		float y = 3.4f;
		Vector3 pared = new Vector3(x,y,z);
		Quaternion rotacion = Quaternion.Euler(0, 0, 180);
		transform.position = pared;
		transform.rotation = rotacion;
	}

	public void Correr()
	{
		float z = transform.position.z;
		float x = 0;
		float y = 0;
		Vector3 pared = new Vector3(x,y,z);
		Quaternion rotacion = Quaternion.identity;
		transform.position = pared;
		transform.rotation = rotacion;
	}




}
