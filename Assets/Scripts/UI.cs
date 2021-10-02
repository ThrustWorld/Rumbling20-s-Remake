using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UI : MonoBehaviour
{
    public GameObject HP;
    public GameObject Scores;

    TextMeshProUGUI[] texts;

    private void Awake()
    {
        texts = new TextMeshProUGUI[3];
        texts[0] = HP.transform.GetChild(1).GetComponent<TextMeshProUGUI>();
        texts[1] = Scores.transform.GetChild(0).GetComponentInChildren<TextMeshProUGUI>();
        texts[2] = Scores.transform.GetChild(1).GetComponentInChildren<TextMeshProUGUI>();
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        texts[0].text = "X " + Player.Hp;
        texts[1].text = "Score: " + Score.CurrentScore;
        texts[2].text = "HighScore:" + Score.HighScore;
    }
}
