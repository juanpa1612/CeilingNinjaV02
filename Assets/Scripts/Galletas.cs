﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Galletas : MonoBehaviour
{
    public int ScorePoints = 0;
    private UIManager gameController;

    public GameObject GameController;
    private GameObject ninja;

    public ParticleSystem particulaGalleta;

    //public AudioClip clip1, clip2;
    public AudioSource [] fuenteAudio = new AudioSource [2];

    public Vector3 posicion = new Vector3 (0.1f,0.1f,0.1f);

    private void Start()
    {
        ninja = GameObject.FindGameObjectWithTag("Player");
        gameController = GameObject.FindWithTag("GameController").GetComponent<UIManager>();
        GameController = GameObject.FindWithTag("GameController");

		particulaGalleta = GameObject.Find ("particulasGalletas").GetComponent<ParticleSystem>();
        fuenteAudio = GameController.GetComponents<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (fuenteAudio[0].isPlaying)
            {
                fuenteAudio[1].Play();
            }
            else
            {
                fuenteAudio[0].Play();
            }
            gameController.points += 1;
            gameObject.SetActive(false);

            particulaGalleta.transform.position = ninja.transform.position + (posicion);
            particulaGalleta.Play();
        }
    }
}
