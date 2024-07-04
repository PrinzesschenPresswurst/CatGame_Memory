using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEditor;
using UnityEngine;
using UnityEngine.Serialization;

public class GameGrid : MonoBehaviour
{
    private float _gridHeight;
    private float _gridWidth;
    private static Camera _cam;

    [SerializeField] private GameObject card;
    public static int CardAmount { get; set; }
    private int _rows;
    private int[,] _gridArray;
    private CardFacePicker _cardFacePicker;
    
    private void Start()
    {
        _rows = DetermineRows();
        _gridArray = new int[_rows,CardAmount/_rows] ;
        _cam = Camera.main;
        
        _cardFacePicker = GetComponent<CardFacePicker>();
        _cardFacePicker.SetCardDeck(CardAmount);
        
        GetGridSize();
        InstantiateCards();
    }

    private int DetermineRows()
    {
        for (int i = 5; i > 1; i--)
        {
            if (CardAmount == i)
                continue;
            
            if (CardAmount % i == 0)
                return CardAmount / i;
        }
        Debug.Log("caught in : " + CardAmount);
        return CardAmount/2;
    }
    
    
    private void GetGridSize()
    { 
        float aspectRatio = (float)Screen.width / (float)Screen.height;
       _gridHeight = 2f * _cam.orthographicSize;
       _gridWidth = _gridHeight * aspectRatio;
       Debug.Log(_gridWidth + "" + _gridHeight);

       Vector3 camPos = new Vector3(_gridWidth/2, _gridHeight/2, -10);
       _cam.transform.position = camPos;

    }
    
    private void InstantiateCards()
    {
        float spacingX = ((float)CardAmount / (float)_rows) +1 ; 
        float spacingY = _rows +1;
        int i = 1;
        int j = 1;
        
        for (int x = 0; x < _gridArray.GetLength(0); x++)
        {
            for (int y = 0; y < _gridArray.GetLength(1); y++)
            {
                Vector2 cardPos = new Vector2(i* (_gridWidth / spacingX) , (j * (_gridHeight / spacingY) ) );
                GameObject currentCard = Instantiate(card, cardPos, Quaternion.identity);
                _cardFacePicker.AttachFaceToCard(currentCard);
                i++;
            }
            i = 1;
            j++;
        }
    }
}
