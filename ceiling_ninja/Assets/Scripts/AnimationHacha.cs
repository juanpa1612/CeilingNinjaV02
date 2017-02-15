using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationHacha : MonoBehaviour {

	public static GameController gameController;

	public void Awake()
	{
		gameController = GameObject.FindWithTag ("GameController").gameObject.GetComponent<GameController> ();
	}

	public void Update()
	{
		if (gameController.reinicio == true) {
			GetComponent<Animator> ().Play ("Axe|AxeAction", -1, 0f);
			gameController.reinicio = false;
		}
	}

	public void RestartAnimation()
	{

	}
}
