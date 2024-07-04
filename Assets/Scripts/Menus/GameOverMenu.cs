using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
   [SerializeField] private TextMeshProUGUI highScoreText;
   [SerializeField] private TextMeshProUGUI yourScoreText;

   private void Start()
   {
      DisplayScores();
   }
   public void LoadMainMenu()
   {
      SceneManager.LoadScene(0);
   }

   private void DisplayScores()
   {
      yourScoreText.text = "Your Score: " + ScoreKeeper.Score;
      highScoreText.text = "HighScore: " + ScoreKeeper.HighScore;
   }
}
