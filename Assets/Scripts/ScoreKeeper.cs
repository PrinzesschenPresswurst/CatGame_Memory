using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    public static int Score { get; set; }
    public static int HighScore { get; set; }
    
    void Start()
    {
        Score = 0;
        UpdateScore();
        RoundHandler.MatchMade += OnMatchMade;
        RoundHandler.Mismatch += OnMismatch;
        RoundHandler.GameEnded += OnGameEnd;
    }   

    private void OnMatchMade()
    {
        Score += 10;
        UpdateScore();
    }

    private void OnMismatch()
    {
        Score -= 2;
        UpdateScore();
    }

    private void UpdateScore()
    {
        scoreText.text = "Score: " + Score;
    }

    private void OnGameEnd()
    {
        if (PlayerPrefs.GetInt("HighScore") != 0)
            HighScore = PlayerPrefs.GetInt("HighScore");
        
        if (Score > HighScore)
            PlayerPrefs.SetInt("HighScore", Score);
        
        RoundHandler.MatchMade -= OnMatchMade;
        RoundHandler.Mismatch -= OnMismatch;
        RoundHandler.GameEnded -= OnGameEnd;
    }
}
