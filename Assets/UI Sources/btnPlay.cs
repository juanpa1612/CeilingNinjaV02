﻿using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class btnPlay : MonoBehaviour
{

	public void JugarNivel ()
    {
        SceneManager.LoadScene("NowWithTextures",LoadSceneMode.Single);
    }

}
