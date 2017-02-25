using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {



    GameObject ninja;
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
        originalPosition = Vector3.zero;
        muerte = false;
        reinicio = false;
        timerMuerte = 0;

        vida = vidasMax;
        textoVida.text = "Vidas: " + vida.ToString();
        textoFinal.text = " ";

        vidaPerder = false;
        timeText = 0;
    }


    void Update()
    {
        if (muerte == true && timerMuerte >= timerMax)
        {
            if (vida > 0)
            {
                ninja.transform.position = originalPosition;
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
            }
        }

        if (script.murio == true)
        {
            muerte = true;
            timerMuerte += Time.deltaTime;

            vidaPerder = true;
            timeText += Time.deltaTime;
        }

        if (vidaPerder == true && timeText >= 1 && timerMuerte <= timeText)
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
    }


    void GameOver()
    {
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
