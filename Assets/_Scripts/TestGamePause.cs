using UnityEngine;
public class TestGamePause : MonoBehaviour
{
    public GameObject GameCanvas;

    bool active = false;
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) && !active)
        {
            GameCanvas.SetActive(true);
            Time.timeScale = 0f;
            active = true;
        }
    }

    public void Resume()
    {
        GameCanvas.SetActive(false);
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
