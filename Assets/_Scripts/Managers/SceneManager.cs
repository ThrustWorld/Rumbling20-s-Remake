using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager : MonoBehaviour
{
    public GameObject GameMenuCanvas;

    bool active = false;
    
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) && !active && 
           UnityEngine.SceneManagement.SceneManager.GetActiveScene().name 
           == "Game")
        {
            GameMenuCanvas.SetActive(true);
            Time.timeScale = 0f;
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
        GameMenuCanvas.SetActive(false);
        active = false;
        Time.timeScale = 1f;
    }

    public void Menu()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Menu");
        active = false;
        Time.timeScale = 1f;
    }
}
