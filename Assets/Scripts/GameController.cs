using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
    private Vector3 pos1, pos2;

    //Reinicio GameOVer
    private GameObject btnReinicio, btnHome;
    private bool hizoPlay;
    private GameObject [] galletas;
    
    

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
        pos1 = new Vector3(0, 0, parte1.transform.position.z + 20f);
        pos2 = new Vector3(0, 0, parte2.transform.position.z + 20f);

        //Botones GameOver
        btnReinicio = GameObject.Find("btnReinicio");
        btnHome = GameObject.Find("btnHome");
        btnHome.SetActive(false);
        btnReinicio.SetActive(false);

        galletas = GameObject.FindGameObjectsWithTag("Galleta");

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
                //Botones GameOVer
                btnReinicio.SetActive(true);
                btnHome.SetActive(true);
                btnReinicio.GetComponent<Animator>().SetInteger("Estado", 1);                
                btnHome.GetComponent<Animator>().SetInteger("Estado", 1);

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
        checkpoint = 0;
    }

    void ShowText()
    {
        textoVida.text = "Vidas: " + vida.ToString();
        if (vida == 0)
        {
            textoFinal.GetComponent<Animator>().SetBool("Anim", true);
            textoFinal.text = "Game Over";
        }
    }

    public void TrueReset()
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

        //Restaurar Galletas
        for (int i = 0; i < galletas.Length; i++)
        {
            galletas[i].SetActive(true);
        }
        gameObject.GetComponent<UIManager>().points = 0;
        //Desaparecer Botones
        btnReinicio.GetComponent<Animator>().SetInteger("Estado",0);
        btnHome.GetComponent<Animator>().SetInteger("Estado", 0);
        textoFinal.GetComponent<Animator>().SetBool("Anim", false);

        btnReinicio.SetActive(false);
        btnHome.SetActive(false);


    }

    public void CargarMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

}
