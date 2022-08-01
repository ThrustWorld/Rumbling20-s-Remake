using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ScoreManager : Singleton<ScoreManager>, ISaveable
{
    public TextMeshProUGUI TextScore;
    public TextMeshProUGUI TextHighscore;
    public TextMeshProUGUI FinalScore;

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
            SetScore();
        }
        
        if(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "GameOver" && !done)
        {
            LoadScore();
            done = true;
        }
    }

    void SetScore()
    {
        currentScore = PlayerController.Instance.gameObject.transform.position.z;
        TextScore.text = currentScore.ToString("0.0") + "m"; // Round off to 1 decimal place and apply the score to the UI
    }

    void SetHighscore(float value)
    {
        TextHighscore.text = value.ToString("0.0") + "m"; 
    }

    void SetFinalscore(float value)
    {
        FinalScore.text = value.ToString("0.0") + "m";
    }
    
    public void Save(SaveSystem data)
    {
        if(currentScore > data.Score.HighScore)
        {
            data.Score.HighScore = currentScore;
        }

        data.Score.FinalScore = currentScore;
    }

    public void Load(SaveSystem data)
    {
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
