using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class CardFacePicker : MonoBehaviour
{
    [SerializeField] private List<Sprite> totalCardFaceList; 
    [SerializeField] private List<Sprite> gameCardFaceList = new List<Sprite>();
    
    public void SetCardDeck(int cardAmount)
    {
        int deckSize = cardAmount / 2;
        PickCardFaces(deckSize);
        DuplicateCardFaces(deckSize);
    }

    private void PickCardFaces(int cardAmount)
    {
        for (int i = 0; i < cardAmount; i++)
        {
            int pickedCard = Random.Range(0, totalCardFaceList.Count);
            gameCardFaceList.Add(totalCardFaceList[pickedCard]);
            totalCardFaceList.RemoveAt(pickedCard);
        }
    }
    
    private void DuplicateCardFaces(int cardAmount)
    {
        for (int i = 0; i < cardAmount; i++)
        {
            gameCardFaceList.Add(gameCardFaceList[i]);
        }
    }

    public void AttachFaceToCard(GameObject card)
    {
        int pickedCard = Random.Range(0, gameCardFaceList.Count);
        SpriteRenderer spriteRenderer = card.GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = gameCardFaceList[pickedCard];
        gameCardFaceList.RemoveAt(pickedCard);
    }
}
