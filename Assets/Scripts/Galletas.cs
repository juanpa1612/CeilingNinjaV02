using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Galletas : MonoBehaviour
{
    public int ScorePoints = 0;
    private UIManager gc;
    public AudioSource sonido;

    private void Start()
    {
        gc = GameObject.FindGameObjectWithTag("GameController").GetComponent<UIManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            this.gameObject.GetComponent<AudioSource>().Play();
            Destroy(this.gameObject);
            gc.points += 1;
            
            
        }
    }
}
