using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoPersonaje : MonoBehaviour {


	//Animaciones
	private Animator animator;

	//Movimiento
	public float velocity = 400;
	private Vector3 movimiento;
	private int lugar;

    //Obstaculos
    public const string OBSTACULO = "obstaculo";
    public float velocidadObstaculos = 2;
    public bool murio;
    Animator animacion;

	//Inicio
	float inicioTimer;
	private Vector3 tempMovimiento;
	public int inicioTimerMax = 10;

	//Animación muerte
	float x = 0;
	float y = 0.1f;//Cambiar esta para lugar de muerte
	float z = 0;
	Vector3 fallTo;
	Vector3 falling = new Vector3 (0, 1, 0);
	bool terminoDeMorir = false;
	public float demora = 4;//Cambiar esto para velocidad de caida.

    //public float velocidad = 2;

    /*
    private bool murio;
    Animator animacion;
    */

    void Awake () 
	{
		//Anim
		animator = GetComponent<Animator> ();

		//Movimiento
		lugar = 0;
		Correr ();
		movimiento = new Vector3 (0, 0, velocity);

		//Inicio
		inicioTimer = 0;

	}

	void Start()
	{

		//Entrada a partida
		Inicio();



        //Obstaculos
        murio = false;
        animacion = this.gameObject.GetComponent<Animator>();
    }


	public void Reinicio()
	{
		lugar = 0;
		inicioTimer = 0;
		murio = false;
		terminoDeMorir = false;
		movimiento = tempMovimiento;
		Cambio ();
		Inicio ();
	}


	public void Update ()
	{
		//Con esto se mueve
		GetComponent<Rigidbody> ().velocity = movimiento * Time.deltaTime;

		//Prueba animaciones/movimiento
		if (murio == false) {
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

		//Inicio Timer
		if (inicioTimer > 0) {
			inicioTimer += Time.deltaTime;
		}

		if (inicioTimer > inicioTimerMax) {
			Salir ();
			animator.SetBool ("Inicio", false);
		}

		//Animación muerte
		if (terminoDeMorir == true) {
			transform.position = Vector3.SmoothDamp(transform.position, fallTo, ref falling, Time.deltaTime*demora);
		}


		//prueba reinicio
		if (Input.GetKeyDown ("r")) {
			Reinicio ();
		}
	}

    //Obstaculos
    private void OnTriggerEnter(Collider other)
    {

        //Debug.Log("Inicio");
        if (other.gameObject.transform.tag.Equals("obstaculo") && murio == false)
        {
            //Debug.Log("Muerte");

        Debug.Log("Inicio");
        if (other.gameObject.transform.tag.Equals("obstaculo") && murio == false)
        {
            Debug.Log("Muerte");

            Muerte();
            murio = true;

        }
        }
    }

    //Entrada a partida
    public void Inicio()
	{
		inicioTimer++;
		tempMovimiento = movimiento;
		movimiento = Vector3.zero;
		animator.SetTrigger("Reinicio");
		animator.SetBool ("Inicio", true);
	}

	public void Salir()
	{
		inicioTimer = 0;
		movimiento = tempMovimiento;
		Correr ();

	}



	//Transición - Salto

    public void Salto()
	{
		animator.SetInteger ("Salto", 1);
	}

	public void FinalSalto()
	{
		animator.SetInteger ("Salto", 0);
	}

	//Cambio de lugar
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


	//Muerte
	public void Muerte()
	{
			tempMovimiento = movimiento;
			movimiento = Vector3.zero;
			animator.SetTrigger("Death");
			GetComponent<Animator> ().Play ("Golpe", -1, 0);
	}

	//Animación de Muerte
	public void MuerteNoSuelo()
	{
		x = transform.position.x;
		z = transform.position.z;
		fallTo = new Vector3 (x, y, z);
		terminoDeMorir = true;
	}



	//Animaciones + movimiento
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

	//Default
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
