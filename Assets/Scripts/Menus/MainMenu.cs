using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    [SerializeField] private int gameSmall = 4;
    [SerializeField] private int gameMedium = 12;
    [SerializeField] private int gameBig = 20;
    
    
    
    public void LoadSmallGame()
    {
        GameGrid.CardAmount = gameSmall;
        SceneManager.LoadScene(1);
    }
    
    public void LoadMediumGame()
    {
        GameGrid.CardAmount = gameMedium;
        SceneManager.LoadScene(1);
    }
    
    public void LoadBigGame()
    {
        GameGrid.CardAmount = gameBig;
        SceneManager.LoadScene(1);
    }
}
