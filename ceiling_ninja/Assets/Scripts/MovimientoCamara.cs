using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoCamara : MonoBehaviour {

	//Camara
	public GameObject player; //Con esto se busca el personaje
	float offset;
	public float damping = 2; //en teoria, cuanto debe de quedarse atrás del jugador

	void Start()
	{
		offset = transform.position.z - player.transform.position.z;
	}

	void LateUpdate()
	{
		float desiredPosition = player.transform.position.z + offset;
		float position = Mathf.Lerp (transform.position.z, desiredPosition, Time.deltaTime * damping);
		transform.position = new Vector3(transform.position.x, transform.position.y, desiredPosition);

	}
}
