using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
   [SerializeField] private TextMeshProUGUI highScoreSmallText;
   [SerializeField] private TextMeshProUGUI highScoreMediumText;
   [SerializeField] private TextMeshProUGUI highScoreBigText;
   [SerializeField] private TextMeshProUGUI yourScoreText;
   [SerializeField] private TextMeshProUGUI scoreBrokenText;

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
      highScoreSmallText.text = "" + PlayerPrefs.GetInt(MainMenu.GameSize.Small.ToString());
      highScoreMediumText.text = "" + PlayerPrefs.GetInt(MainMenu.GameSize.Medium.ToString());
      highScoreBigText.text = "" + PlayerPrefs.GetInt(MainMenu.GameSize.Big.ToString());

      if (ScoreKeeper.Score > ScoreKeeper.HighScore)
      {
         yourScoreText.color = Color.yellow;
         scoreBrokenText.text = "you broke the high score!";
      }
      else 
         scoreBrokenText.text = " ";
   }
}
