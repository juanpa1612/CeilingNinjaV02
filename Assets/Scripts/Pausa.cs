using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pausa : MonoBehaviour {

	public int setPausa;

	void Awake ()
	{
		setPausa = 0;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetKeyDown(KeyCode.Space))
		{
			Pausar ();
		}

	}

	public void Pausar()
	{
		if (setPausa == 0) 
		{
			Time.timeScale = 0;
			AudioListener.pause = true;
			setPausa = 1;
		}

		else if (setPausa == 1) 
		{
			Time.timeScale = 1;
			AudioListener.pause = false;
			setPausa = 0;
		}
	}
}
