using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Galletas : MonoBehaviour
{
    public int ScorePoints = 0;
    private UIManager gameController;

    public GameObject GameController;
    private GameObject ninja;

    public ParticleSystem particulaGalleta;

    public Vector3 posicion = new Vector3 (0.1f,0.1f,0.1f);

    private void Start()
    {
        ninja = GameObject.FindGameObjectWithTag("Player");
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<UIManager>();
        GameController = GameObject.FindGameObjectWithTag("GameController");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameController.GetComponent<AudioSource>().Play();
            gameController.points += 1;
            gameObject.SetActive(false);

            particulaGalleta.transform.position = ninja.transform.position + (posicion);
            particulaGalleta.Play();
        }
    }
}
