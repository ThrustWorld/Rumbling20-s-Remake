using UnityEngine;
public class TestGamePause : MonoBehaviour
{
    public GameObject GameCanvas;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            GameCanvas.SetActive(true);
            Time.timeScale = 0f;
        }
    }

    public void Resume()
    {
        GameCanvas.SetActive(false);
        Time.timeScale = 1f;
    }

    public void Menu()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Menu");
        Time.timeScale = 1f;
    }
}
