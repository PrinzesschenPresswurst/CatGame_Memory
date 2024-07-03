using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Serialization;

public class GameGrid : MonoBehaviour
{
    private float _gridHeight;
    private float _gridWidth;
    private static Camera _cam;

    [SerializeField] private GameObject card;
    [SerializeField] private int cardAmount = 4;
    private int _rows;
    private int[,] _gridArray;
    private CardFacePicker _cardFacePicker;
    
    private void Start()
    {
        _rows = DetermineRows();
        _gridArray = new int[_rows,cardAmount/_rows] ;
        _cam = Camera.main;
        
        _cardFacePicker = GetComponent<CardFacePicker>();
        _cardFacePicker.SetCardDeck(cardAmount);
        
        GetGridSize();
        InstantiateCards();
    }

    private int DetermineRows()
    {
        for (int i = cardAmount; i > 1; i--)
        {
            if (cardAmount == i)
                continue;
            
            if (cardAmount % i == 0)
                return cardAmount / i;
        }
        Debug.Log("caught in : " + cardAmount);
        return cardAmount/2;
    }

    private void GetGridSize()
    {
        _gridHeight = 2f * _cam.orthographicSize;
        _gridWidth = _gridHeight * _cam.aspect;
    }

    private void InstantiateCards()
    {
        int spacingX = (cardAmount / _rows) + 1 ; 
        int spacingY = _rows+1;
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
