﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CorrerPared : MonoBehaviour {
	/*
	private bool isWallR;
	private bool isWallL;
	private RaycastHit hitR;
	private RaycastHit hitL;
	private int jumpCount = 0;
	private Rigidbody rb;
	private RigidbodyPersonaje cc;
	public float runTime = 0.5f;


	void Start () {
		cc = GetComponent<RigidbodyPersonaje>(); 
		rb = GetComponent<Rigidbody>();
	}

	// Update is called once per frame
	void Update () {
		if (cc.grounded)
		{
			jumpCount = 0;
		}
		if (Input.GetKeyDown(KeyCode.E) && !cc.Grounded && jumpCount <= 1)
		{
			if (Physics.Raycast(transform.position, -transform.right, out hitL, 1))
			{
				if (hitL.transform.tag == "wall")
				{
					isWallL = true;
					isWallR = false;
					jumpCount += 1;
					rb.useGravity = false;
					StartCoroutine(afterRun());
				}
			}
			if (Physics.Raycast(transform.position, transform.right, out hitR, 1))
			{
				if (hitL.transform.tag == "wall")
				{
					isWallL =false;
					isWallR = true;
					jumpCount += 1;
					rb.useGravity = false;
					StartCoroutine(afterRun());
				}
			}
		}
	}
	IEnumerator afterRun()
	{
		yield return new WaitForSeconds(runTime);

		isWallL = false;
		isWallR = false;
		rb.useGravity = true;
	}

*/
}
