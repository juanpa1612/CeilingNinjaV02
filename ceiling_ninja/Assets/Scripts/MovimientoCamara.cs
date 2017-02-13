using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoCamara : MonoBehaviour {

	public GameObject player;
	float offset;
	public float damping = 1;

	void Start()
	{
		offset = transform.position.z - player.transform.position.z;
	}

	void LateUpdate()
	{
		float desiredPosition = player.transform.position.z + offset;
		//float position = Mathf.Lerp (transform.position.z, desiredPosition, Time.deltaTime * damping);
		transform.position = new Vector3(transform.position.x, transform.position.y, desiredPosition);

	}
}
