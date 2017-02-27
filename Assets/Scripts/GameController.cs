using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {



    GameObject ninja;
    public ParticleSystem partiSangre;
    MovimientoPersonaje script;

    Vector3 playerPosition;
    Vector3 originalPosition;

    bool muerte;
    public bool reinicio; //para el hacha


    float timerMuerte;
    public float timerMax = 5;

    //Vidas
    public int vidasMax = 3;
    int vida;
    float timeText;
    bool vidaPerder;
    Text textoVida;
    Text textoFinal;

    //Checkpoint
    public int checkpoint;
    public GameObject parte1, parte2;
    private Vector3 poscheckpoint1, poscheckpoint2,pos1,pos2;

    //Bool que detecta si está jugando o no
    bool jugando;

    //Setter Y Getter
    public bool Muerte
    {
        get
        {
            return muerte;
        }

        set
        {
            muerte = value;
        }
    }

    void Awake()
    {
        ninja = GameObject.FindWithTag("Player");
        script = ninja.GetComponent<MovimientoPersonaje>();
        playerPosition = ninja.transform.position;
        textoVida = GameObject.Find("VidaUI").GetComponent<Text>();
        textoFinal = GameObject.Find("FinalUI").GetComponent<Text>();
    }

    void Start()
    {
		jugando = true;
        originalPosition = Vector3.zero;
        muerte = false;
        reinicio = false;
        timerMuerte = 0;

        vida = vidasMax;
        textoVida.text = "Vidas: " + vida.ToString();
        textoFinal.text = " ";

        vidaPerder = false;
        timeText = 0;

        //Checkpoint
        checkpoint = 0;
        poscheckpoint1 = parte1.transform.position;
        poscheckpoint2 = parte2.transform.position;
        pos1 = new Vector3 (0,0,parte1.transform.position.z + 20f);
        pos2 = new Vector3(0, 0,parte2.transform.position.z + 20f);

    }


    void Update()
    {
        if (muerte == true && timerMuerte >= timerMax)
        {
            if (vida > 0)
            {
                //Checkpoint
                if (checkpoint==0)
                {
                    ninja.transform.position = originalPosition;
                }
                if (checkpoint == 1)
                {
                    ninja.transform.position = pos1 ;
                }
                if (checkpoint == 2)
                {
                    ninja.transform.position = pos2;
                }
                //ninja.transform.position = originalPosition;
                script.Reinicio();
                muerte = false;
                timerMuerte = 0;

                vidaPerder = false;
                timeText = 0;
                reinicio = true;

            }
            else
            {
                GameOver();
				vida = 0;
            }
        }

        if (script.murio == true)
        {
            muerte = true;
            timerMuerte += Time.deltaTime;

            vidaPerder = true;
            timeText += Time.deltaTime;
        }

        if (vidaPerder == true && timeText >= 1 && timerMuerte <= timeText && jugando)
        {
            vida--;
            ShowText();
            vidaPerder = false;
            timeText = 0;
        }

        //prueba reinicio
        if (Input.GetKeyDown("r"))
        {
            muerte = true;
            timerMuerte = timerMax;
        }

        if (Input.GetKeyDown("k"))
        {
            muerte = true;
            timerMuerte = timerMax;
            TrueReset();
        }
        
        //Se activa la particula de sangre en el PJ
        if (script.murio == true)
        {
            StartCoroutine(playParticulaSangre());
        }
    }

    IEnumerator playParticulaSangre ()
    {
        partiSangre.transform.position = ninja.transform.position;
        partiSangre.Play();

        yield return new WaitForSeconds(1f);

        partiSangre.Stop();

    }


    void GameOver()
    {
		jugando = false;
        timerMuerte = 0;

        vidaPerder = false;
        timeText = 0;
        ShowText();
    }

    void ShowText()
    {
        textoVida.text = "Vidas: " + vida.ToString();
        if (vida == 0)
        {
            textoFinal.text = "Game Over";
        }
    }

    void TrueReset()
    {
		jugando = true;

        originalPosition = Vector3.zero;
        muerte = false;
        reinicio = false;
        timerMuerte = 0;

        vida = vidasMax;
        textoVida.text = "Vidas: " + vida.ToString();
        textoFinal.text = " ";

        vidaPerder = false;
        timeText = 0;

        ninja.transform.position = originalPosition;
        script.Reinicio();
        muerte = false;
        timerMuerte = 0;

        vidaPerder = false;
        timeText = 0;
        reinicio = true;
    }


}
