﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoPersonaje : MonoBehaviour {


    //Animaciones
    private Animator animator;
    float desiredPosition;
    float position;
    Quaternion desiredRotation;
    Quaternion rotation;
    float damping = 5;
    float xAct;
    float zAct;

    //Particulas
    public ParticleSystem efecto;
	public ParticleSystem efectoMuerte;

    //Movimiento
    public float velocity = 900;
    private Vector3 movimiento;
    public int lugar;
    private int lugarActual;

    //Obstaculos
    public const string OBSTACULO = "obstaculo";
    public float velocidadObstaculos = 2;
    public bool murio;
    Animator animacion;

    //Inicio
    public bool iniciando;
    float inicioTimer;
    private Vector3 tempMovimiento;
    public int inicioTimerMax = 10;

    //Animación muerte
    float x = 0;
    float y = 0f;//Cambiar esta para lugar de muerte
    float z = 0;
    Vector3 fallTo;
    Vector3 falling = new Vector3(0, 1, 0);
    bool terminoDeMorir = false;
    public float demora = 4;//Cambiar esto para velocidad de caida.

    //Checkpoint y Reinicio
    public GameObject gc;



    void Awake()
    {
        //Anim
        animator = GetComponent<Animator>();

        //Movimiento
        lugar = 0;
        Correr();
        movimiento = new Vector3(0, 0, velocity);

        //Inicio
        iniciando = true;
        inicioTimer = 0;

        //Efectos
        efecto = GameObject.Find("Explosion").GetComponent<ParticleSystem>();
		efectoMuerte = GameObject.Find ("ExplosionDeath").GetComponent<ParticleSystem> ();

    }

    void Start()
    {

        gc = GameObject.FindGameObjectWithTag("GameController");
       
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
        Cambio();
        Inicio();
    }


	public void FixedUpdate()
	{
		if (iniciando == false) 
		{
			//Con esto se mueve
			GetComponent<Rigidbody> ().velocity = movimiento * Time.deltaTime;
		}

		//Inicio Timer
		if (inicioTimer > 0)
		{
			inicioTimer += Time.deltaTime;
		}

		if (inicioTimer > inicioTimerMax)
		{
			Salir();
			animator.SetBool("Inicio", false);
		}

		//Animación muerte
		if (terminoDeMorir == true)
		{
			//transform.position = Vector3.SmoothDamp(transform.position, fallTo, ref falling, Time.deltaTime * demora);
		}

		//Animación cambio despacio
		position = Mathf.Lerp(transform.position.y, desiredPosition, Time.deltaTime * damping);
		transform.position = new Vector3(transform.position.x, position, transform.position.z);

		//transform.rotation = Quaternion.Lerp(transform.rotation, desiredRotation,  Time.deltaTime * damping);
	}


    public void Update()
    {
        if (iniciando == false)
        {
           //Prueba animaciones/movimiento
            if (murio == false)
            {
                if (Input.GetKeyDown("space"))
                {
                    Salto();
                }

                if (Input.GetKeyDown("w"))
                {
                    lugar = 2;
                    Salto();

                }

                if (Input.GetKeyDown("d"))
                {
                    lugar = 3;
                    Salto();
                }

                if (Input.GetKeyDown("a"))
                {
                    lugar = 1;
                    Salto();

                }

                if (Input.GetKeyDown("s"))
                {
                    lugar = 0;
                    Salto();
                }

                if (Input.GetKeyDown("g"))
                {
                    Muerte();
                }
            }

        }

        //prueba reinicio
        if (Input.GetKeyDown("r"))
        {
            Reinicio();
        }
			
    }

    //Obstaculos
    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.transform.tag.Equals("obstaculo") && murio == false)
        {
            if (other.gameObject.transform.tag.Equals("obstaculo") && murio == false)
            {
                Muerte();
                murio = true;
            }
        }
    }

    //Entrada a partida
    public void Inicio()
    {
        iniciando = true;
        inicioTimer++;
        tempMovimiento = movimiento;
        movimiento = Vector3.zero;
        animator.SetTrigger("Reinicio");
        animator.SetBool("Inicio", true);
    }

    public void Salir()
    {
        inicioTimer = 0;
        movimiento = tempMovimiento;
        iniciando = false;
        Correr();

    }

    //Transición - Salto

    public void Salto()
    {
        if (iniciando == false)
        {
            if (lugarActual != lugar)
            {
                animator.SetInteger("Salto", 1);
            }
        }
    }

    public void FinalSalto()
    {
        if (iniciando == false)
        {
            animator.SetInteger("Salto", 0);
            efecto.Stop(true);
        }
    }


    //Efecto cuando cambia
    public void IniciarEfecto()
    {
        efecto.transform.position = new Vector3(0, 1.5f, transform.position.z + 1);
        efecto.Play(true);
    }


	//Efecto cuando muere
	public void IniciarEfectoMuerte()
	{
		efectoMuerte.transform.position = new Vector3(0, 1.5f, transform.position.z - 1);
		efectoMuerte.Play(true);
	}

    //Cambio de lugar
    public void Cambio()
    {
        if (iniciando == false)
        {
            if (lugarActual != lugar)
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
        }
    }


    //Muerte
    public void Muerte()
    {
        tempMovimiento = movimiento;
        movimiento = Vector3.zero;
        animator.SetTrigger("Death");
        GetComponent<Animator>().Play("Golpe", -1, 0);
		efecto.Stop (true);
    }

    //Animación de Muerte
    public void MuerteNoSuelo()
    {
		if (lugarActual != 0) {
			x = 0;
			y = 0;
			z = transform.position.z;
			Quaternion rotacion = Quaternion.identity;
			transform.rotation = rotacion;
			transform.position = new Vector3 (x, y, z);
			desiredPosition = y;

			IniciarEfectoMuerte ();
			terminoDeMorir = true;
		}
    }



    //Animaciones + movimiento
    public void CorrerDerecha()
    {
        lugarActual = 3;

        float z = transform.position.z;
        float x = 1.3f;
        float y = 2;
        Vector3 pared = new Vector3(x, y, z);
        Quaternion rotacion = Quaternion.Euler(0, 0, 90);
        transform.position = pared;
        transform.rotation = rotacion;

        xAct = x;
        zAct = z;
        desiredPosition = y;
        desiredRotation = rotacion;
    }

    public void CorrerIzquierda()
    {
        lugarActual = 1;

        float z = transform.position.z;
        float x = -1.3f;
        float y = 2;
        Vector3 pared = new Vector3(x, y, z);
        Quaternion rotacion = Quaternion.Euler(0, 0, -90);
        transform.position = pared;
        transform.rotation = rotacion;

        xAct = x;
        zAct = z;
        desiredPosition = y;
    }

    public void CorrerTecho()
    {
        lugarActual = 2;

        float z = transform.position.z;
        float x = 0;
        float y = 3.4f;
        Vector3 pared = new Vector3(x, y, z);
        Quaternion rotacion = Quaternion.Euler(0, 0, 180);
        transform.position = pared;
        transform.rotation = rotacion;

        xAct = x;
        zAct = z;
        desiredPosition = y;
    }

    //Default
    public void Correr()
    {
        lugarActual = 0;

        float z = transform.position.z;
        float x = 0;
        float y = 0;
        Vector3 pared = new Vector3(x, y, z);
        Quaternion rotacion = Quaternion.identity;
        transform.position = pared;
        transform.rotation = rotacion;

        xAct = x;
        zAct = z;
        desiredPosition = y;
    }

}
