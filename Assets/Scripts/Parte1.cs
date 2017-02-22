using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Parte1 : MonoBehaviour {

    public Text checkpoint;

    private void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            checkpoint.text = ("Sigue Asi!");
            checkpoint.GetComponent<Animator>().SetInteger("paso", 1);
        }
    }
}
