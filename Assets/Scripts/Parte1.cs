using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Parte1 : MonoBehaviour {

    public Text checkpoint;
    private Color colorOriginal;
    public string texto = "Muy Bien!";

    private void Start()
    {
        colorOriginal = new Color(0, 0, 0, 1);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            checkpoint.gameObject.SetActive(true);
            checkpoint.text = (texto);
            checkpoint.GetComponent<Animator>().SetInteger("paso", 1);
            StartCoroutine("Animacion");
            
            
        }
    }

    public IEnumerator Animacion  ()
    {
        yield return new WaitForSeconds(5);
        checkpoint.color = colorOriginal;
        checkpoint.GetComponent<Animator>().SetInteger("paso", 0);
        checkpoint.gameObject.SetActive(false); 
    } 
}
