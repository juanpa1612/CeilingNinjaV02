using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class btnCreditos : MonoBehaviour

{

    public GameObject menu,creditos,flecha;



    private Animator animMenu;

    private void Awake()
    {
        creditos.SetActive(false);
    }
    // Use this for initialization
    void Start ()
    {
        
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void Creditos()
    {

        menu.GetComponent<Animator>().SetInteger("Estado", 1);//Fade Out Menu

        flecha.SetActive(true);
        flecha.GetComponent<Animator>().SetInteger("Estado", 1);//Fade In Flecha

        creditos.SetActive(true);
        creditos.GetComponent<Animator>().SetInteger("Estado",1);//Fade In Creditos

    }

    public void VolverMenu()
    {
        creditos.GetComponent<Animator>().SetInteger("Estado", 2);//FAde Out Creditos
        flecha.GetComponent<Animator>().SetInteger("Estado", 2);//Fade Out Flecha
        menu.GetComponent<Animator>().SetInteger("Estado",2);//Fade In Menu
        StartCoroutine("MenuDefault");
    }
    IEnumerator MenuDefault ()
    {
        yield return new WaitForSeconds(2);
        //Todos Pasan al Estado Default
        creditos.GetComponent<Animator>().SetInteger("Estado", 3);
        menu.GetComponent<Animator>().SetInteger("Estado", 3);
        flecha.GetComponent<Animator>().SetInteger("Estado", 3);
        creditos.SetActive(false);
        flecha.SetActive(false);
    }
}
