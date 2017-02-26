using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeControl : MonoBehaviour
{
    MovimientoPersonaje personaje;

    private float swipeTimer;
    private float timerMax = 1.6f;

    Vector2 firstPressPos;
    Vector2 secondPressPos;
    Vector2 currentSwipe;

    public void Awake()
    {
        personaje = GameObject.FindWithTag("Player").GetComponent<MovimientoPersonaje>();
        swipeTimer = 0;
    }

    public void Update()
    {
        if (personaje.iniciando == false)
        {
            if (Input.GetMouseButtonDown(0))
            {
                //save began touch 2d point
                firstPressPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            }


            if (Input.GetMouseButtonUp(0))
            {
                Swipe();
            }


			//Para mantener dedo cuando salta
			/*
            if (swipeTimer >= 1)
            {
                swipeTimer += Time.deltaTime;
                if (Input.GetMouseButton(0))
                {
                    swipeTimer = 1.5f;
                }
            }

            if (swipeTimer >= timerMax)
            {
                personaje.lugar = 0;
                personaje.Salto();
                swipeTimer = 0;
            }
            */
        }
    }

    public void Swipe()
    {
        //save ended touch 2d point
        secondPressPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);

        //create vector from the two points
        currentSwipe = new Vector2(secondPressPos.x - firstPressPos.x, secondPressPos.y - firstPressPos.y);

        //normalize the 2d vector
        currentSwipe.Normalize();
        Debug.Log(currentSwipe);

        //swipe upwards
        if (currentSwipe.y > 0 && currentSwipe.x > -0.5f && currentSwipe.x < 0.5f)
        {
            Debug.Log("up swipe");
            personaje.lugar = 2;
            personaje.Salto();
            swipeTimer = 1;
        }
        //swipe down
        if (currentSwipe.y < 0 && currentSwipe.x > -0.5f && currentSwipe.x < 0.5f)
        {
            Debug.Log("down swipe");
            personaje.lugar = 0;
            personaje.Salto();
        }
        //swipe left
        if (currentSwipe.x < 0 && currentSwipe.y > -0.5f && currentSwipe.y < 0.5f)
        {
            Debug.Log("left swipe");
            personaje.lugar = 1;
            personaje.Salto();
            swipeTimer = 1;
        }
        //swipe right
        if (currentSwipe.x > 0 && currentSwipe.y > -0.5f && currentSwipe.y < 0.5f)
        {
            Debug.Log("right swipe");
            personaje.lugar = 3;
            personaje.Salto();
            swipeTimer = 1;
        }
    }

}
