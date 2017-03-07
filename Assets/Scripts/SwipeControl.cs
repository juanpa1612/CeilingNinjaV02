using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeControl : MonoBehaviour
{
    MovimientoPersonaje personaje;

	//Para pausar controles
	Pausa pausa;

    private float timerMax = 1.6f;

	//PAra evitar demasiados swipes
	private float swipeTimer;
	private float currentlyHere;
	private float whereAmI;

    Vector2 firstPressPos;
    Vector2 secondPressPos;
    Vector2 currentSwipe;

    public void Awake()
    {
        personaje = GameObject.FindWithTag("Player").GetComponent<MovimientoPersonaje>();
		pausa = GameObject.FindWithTag ("GameController").GetComponent<Pausa> ();
		swipeTimer = 0;

		currentlyHere = 0;
		whereAmI = currentlyHere;
    }

	public void FixedUpdate()
	{
		if (swipeTimer >= 1) 
		{
			swipeTimer += Time.deltaTime;

			if (swipeTimer >= 1.3f) 
			{
				swipeTimer = 0;
			}
		}
	}

    public void Update()
    {
		if (personaje.iniciando == false && personaje.murio == false && pausa.setPausa == 0)
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

        //swipe upwards
		if (swipeTimer == 0 && personaje.murio == false) //Para que funcione el swipe
		{
			if (currentSwipe.y > 0 && currentSwipe.x > -0.5f && currentSwipe.x < 0.5f) {
				personaje.lugar = 2;

				currentlyHere = 2;

				personaje.Salto ();

				if (whereAmI != currentlyHere) 
				{
					whereAmI = currentlyHere;
					swipeTimer = 1;
				}
			}
			//swipe down
			if (currentSwipe.y < 0 && currentSwipe.x > -0.5f && currentSwipe.x < 0.5f) {
				personaje.lugar = 0;

				currentlyHere = 0;

				personaje.Salto ();

				if (whereAmI != currentlyHere) 
				{
					whereAmI = currentlyHere;
					swipeTimer = 1;
				}
			}
			//swipe left
			if (currentSwipe.x < 0 && currentSwipe.y > -0.5f && currentSwipe.y < 0.5f) {
				personaje.lugar = 1;

				currentlyHere = 1;

				personaje.Salto ();

				if (whereAmI != currentlyHere) 
				{
					whereAmI = currentlyHere;
					swipeTimer = 1;
				}
			}
			//swipe right
			if (currentSwipe.x > 0 && currentSwipe.y > -0.5f && currentSwipe.y < 0.5f) {
				personaje.lugar = 3;

				currentlyHere = 3;

				personaje.Salto ();

				if (whereAmI != currentlyHere) 
				{
					whereAmI = currentlyHere;
					swipeTimer = 1;
				}
			}
		}
    }

}
