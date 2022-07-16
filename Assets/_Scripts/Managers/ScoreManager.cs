using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ScoreManager : Singleton<ScoreManager>, ISaveable
{
    public TextMeshProUGUI TextScore;
    public TextMeshProUGUI TextHighscore;
    
    float currentScore;

    private void Start()
    {
        currentScore = 100;
        LoadScore();
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.Instance.State != GameState.Flow)
            return;
        SetScore();
    }

    void SetScore()
    {
        currentScore = PlayerController.Instance.gameObject.transform.position.z;
        TextScore.text = currentScore.ToString("0.0") + "m"; // Round off to 1 decimal place and apply the score to the UI
    }

    void SetHighscore(float value)
    {
        TextHighscore.text = value + "m"; 
    }

    public void Save(SaveSystem data)
    {
        data.Score.HighScore = currentScore;
    }

    public void Load(SaveSystem data)
    {
        SetHighscore(data.Score.HighScore);
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
        }
    }
}
