using UnityEngine;
using System.Collections;

public class FadeManager : Singleton<FadeManager>
{
    public CanvasGroup Canvas;

    bool done = false;

    public IEnumerator Fade(float alpha)
    {
        for (float i = alpha; i < 1f; i += 0.01f)
        {
            Canvas.alpha = i;
            yield return null;
        }
        
        if(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "Game")
        {
            SceneManager.Instance.LoadScene("GameOver");
        }
    }


    void Update()
    {
         if(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "GameOver" && !done)
        {
            StartCoroutine(Fade(0));
            done = true;
        }
    }
}
