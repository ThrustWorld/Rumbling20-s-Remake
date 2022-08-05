using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ScoreManager : Singleton<ScoreManager>, ISaveable
{
    public TextMeshProUGUI TextScore; // Current score during the game
    public TextMeshProUGUI TextHighscore; // The best score
    public TextMeshProUGUI FinalScore; // Gameover score

    float currentScore;
    bool done = false;

    private void Start()
    {
        currentScore = 0;
        LoadScore();
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.Instance.State == GameState.Flow)
        {
            SetScore(); // Update score during the game
        }
        
        if(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "GameOver" && !done)
        {
            LoadScore(); // Score after the gameover
            done = true;
        }
    }

    void SetScore()
    {
        currentScore = PlayerController.Instance.gameObject.transform.position.z; // Based on the distance crossed by the player
        TextScore.text = currentScore.ToString("0.0") + "m"; // Round off to 1 decimal place and apply the score to the UI
    }

    void SetHighscore(float value)
    {
        TextHighscore.text = value.ToString("0.0") + "m"; // Round off to 1 decimal place and apply the score to the UI
    }

    void SetFinalscore(float value)
    {
        FinalScore.text = value.ToString("0.0") + "m"; // Round off to 1 decimal place and apply the score to the UI
    }
    
    public void Save(SaveSystem data)
    {
        // Update the highscore if the current score is better
        if(currentScore > data.Score.HighScore) 
        {
            data.Score.HighScore = currentScore;
        }

        data.Score.FinalScore = currentScore;
    }

    public void Load(SaveSystem data)
    {
        // Load the last score before the gameover and the highscore before start playing again
        if(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "GameOver")
        {
            SetFinalscore(data.Score.FinalScore);
        }
        else
        {
            SetHighscore(data.Score.HighScore);
        }
    }
    
    public void SaveScore()
    {
        SaveSystem data = new SaveSystem();
        data.Score = new PlayerScore();
        Save(data);
        if(Helpers.WriteToFile("Score.txt", data.ToJson(data.Score)))
        {
            Debug.Log("Save");
        }
    }

    void LoadScore()
    {
        if(Helpers.LoadFromFile("Score.txt", out var txt))
        {
            SaveSystem data = new SaveSystem();
            data.Score = new PlayerScore();
            data.LoadFromJson(txt,data.Score);
            Load(data);
            Debug.Log("Loading");
        }
    }
}
