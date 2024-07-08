using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    
    public void LoadSmallGame()
    {
        LoadGame(GameSize.Small);
    }
    
    public void LoadMediumGame()
    {
        LoadGame(GameSize.Medium);
    }
    
    public void LoadBigGame()
    {
        LoadGame(GameSize.Big);
    }

    private void LoadGame(GameSize size)
    {
        switch (size)
        {
            case GameSize.Small:
                GameGrid.CardAmount = 4;
                break;
            case GameSize.Medium :
                GameGrid.CardAmount = 12;
                break;
            case GameSize.Big:
                GameGrid.CardAmount = 20;
                break;
        }

        SceneManager.LoadScene(1);
        GameGrid.GameSize = size;
    }
    
    public enum GameSize
    {
        Big,
        Medium,
        Small
    }
}
