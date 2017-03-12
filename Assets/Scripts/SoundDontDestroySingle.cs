using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundDontDestroySingle : MonoBehaviour {

	[SerializeField]

	private static SoundDontDestroySingle instance = null;

	public static SoundDontDestroySingle Instance {
		get { return instance; }
	}

	void Awake() 
	{
		if (instance != null && instance != this) 
		{
			//Destroy (this.gameObject);
			return;
		}

		else 

		{
			instance = this;

		}

		DontDestroyOnLoad(this.gameObject);
	}

	public void PlaySound()
	{
		GetComponent<AudioSource> ().Play ();
	}
}
