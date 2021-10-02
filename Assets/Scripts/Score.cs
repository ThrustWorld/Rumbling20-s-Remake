using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    public static int CurrentScore;
    public static int HighScore;

    private float time;

    private float counter;
    private void Start()
    {
        CurrentScore = 0;
        time = 20;
    }

    // Update is called once per frame
    void Update()
    {
        counter += Time.deltaTime;
        if(counter >= time)
        {
            CurrentScore += 5;
            counter = 0;
        }

        if(HighScore < CurrentScore)
        {
            HighScore = CurrentScore;
        }
    }
}
