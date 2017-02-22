using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {


	GameObject ninja;
	MovimientoPersonaje script;

	Vector3 playerPosition;
	Vector3 originalPosition;

	private bool muerte;
	public bool reinicio; //para el hacha

	float timerMuerte;
	public float timerMax = 5;

    //Setter Y Getter
    public bool Muerte
    {
        get
        {
            return muerte;
        }

        set
        {
            muerte = value;
        }
    }

    void Awake () {
		ninja = GameObject.FindWithTag ("Player");
		script = ninja.GetComponent<MovimientoPersonaje> ();
		playerPosition = ninja.transform.position;
	}

	void Start () {
		originalPosition = Vector3.zero;
		muerte = false;
		reinicio = false;
		timerMuerte = 0;
	}
	

	void Update () {
		if (muerte == true && timerMuerte >= timerMax) {
			ninja.transform.position = originalPosition;
			script.Reinicio ();
			muerte = false;
			timerMuerte = 0;
			reinicio = true;
		}

		if (script.murio == true) {
			muerte = true;
			timerMuerte += Time.deltaTime;
		}

		//prueba reinicio
		if (Input.GetKeyDown ("r")) {
			muerte = true;
			timerMuerte = timerMax;
		}
	}
		
}
