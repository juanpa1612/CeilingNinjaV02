using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimController : MonoBehaviour {

	private Animator animator;
	public float velocity;

	void Awake () 
	{
		animator = GetComponent<Animator> ();
		Correr ();
	}

	void Update () 
	{
		transform.Translate (Vector3.forward * velocity * Time.deltaTime);
		if (Input.GetKeyDown ("space")) {
			Salto ();
		}

		if (Input.GetKeyDown ("w")) {
			CorrerTecho();
		}

		if (Input.GetKeyDown ("d")) {
			CorrerDerecha();
		}

		if (Input.GetKeyDown ("a")) {
			CorrerIzquierda();
		}

		if (Input.GetKeyDown ("s")) {
			Correr();
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
