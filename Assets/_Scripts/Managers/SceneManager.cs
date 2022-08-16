using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SceneManager : Singleton<SceneManager>
{
    [SerializeField] GameObject _gameMenuCanvas;

    bool active = false;
    
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) && !active && 
           UnityEngine.SceneManagement.SceneManager.GetActiveScene().name 
           == "Game")
        {
            _gameMenuCanvas.SetActive(true);
            Time.timeScale = 0f; // Pause
            active = true;
            AudioSystem.Instance.Pause(PlayerController.Instance.Source);
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
        _gameMenuCanvas.SetActive(false);
        active = false;
        Time.timeScale = 1f; // Unpause
        AudioSystem.Instance.Unpause(PlayerController.Instance.Source);
    }

    public void Menu()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Menu");
        active = false;
        Time.timeScale = 1f;
    }
}
