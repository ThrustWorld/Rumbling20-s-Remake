using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SceneManager : Singleton<SceneManager>
{
    [SerializeField] GameObject _GameMenuCanvas;

    bool active = false;
    
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) && !active && 
           UnityEngine.SceneManagement.SceneManager.GetActiveScene().name 
           == "Game")
        {
            _GameMenuCanvas.SetActive(true);
            Time.timeScale = 0f; // Pause
            active = true;
        }
    }

    public void LoadScene(string name)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(name);
    }


    public void Quit()
    {
        Application.Quit();
    }

     public void Resume()
    {
        _GameMenuCanvas.SetActive(false);
        active = false;
        Time.timeScale = 1f; // Unpause
    }

    public void Menu()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Menu");
        active = false;
        Time.timeScale = 1f;
    }
}
