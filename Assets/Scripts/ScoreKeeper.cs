using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    private int Score { get; set; }
    
    void Start()
    {
        UpdateScore();
        RoundHandler.MatchMade += OnMatchMade;
        RoundHandler.Mismatch += OnMismatch;
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
}
