using UnityEngine;
using System.Collections;

public class Obstaculos : MonoBehaviour {

    public const string OBSTACULO = "obstaculo";
    public float velocidad =2;
    public bool murio;
    Animator animacion;
    /*
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Inicio");
        if (collision.gameObject.transform.tag.Equals ("obstaculo"))
        {
            Debug.Log("Muerte");
        }
    }
    */
    private void Start()
    {
        murio = false;
        animacion = this.gameObject.GetComponent<Animator>();
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Inicio");
        if (other.gameObject.transform.tag.Equals("obstaculo"))
        {
            Debug.Log("Muerte");
            animacion.SetTrigger("Muerte");
            murio = true;

        }
    }
    
    
}
