﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Main_menu : MonoBehaviour {

	/*public void play ()
    {
        //SceneManager.LoadScene("Play");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }*/
    public void quit ()
    {
        Debug.Log("QUIT!");
        Application.Quit();
    }
}
