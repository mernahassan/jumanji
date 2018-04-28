using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause_menu : MonoBehaviour {
    private static Pause_menu instance;
    public static bool isPaused = false; 
    public GameObject pauseMenu;

	
	// Update is called once per frame
	void Update () {
        if(Input.GetKeyDown(KeyCode.Escape)){
            if (isPaused)
                Resume();
            else
                Pause();
        }
       
            instance = this;
           // DontDestroyOnLoad(transform.gameObject);
        
       
		
	}

    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }

    void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void loading_menu()
    {
        SceneManager.LoadScene("Menus");
    }

    public void quit()
    {
        Application.Quit();
        Debug.Log("QUIT!!");
    }
}
