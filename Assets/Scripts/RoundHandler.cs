using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class RoundHandler : MonoBehaviour
{
    private Card firstCard { get; set; }
    private Card secondCard { get; set; }

    private bool roundIsOver = false;
    
    public static event Action? MatchMade;
    [CanBeNull] public static event Action Mismatch;
    
    
    void Start()
    {
        Card.CardClicked += OnCardClicked;
    }

    private void OnCardClicked(Card card)
    {
        if (roundIsOver)
        {
            EvaluateRoundResult();
            CleanupRound();
            return;
        }
        
        RevealCard(card);
        StoreCardChoice(card);
        
        if (firstCard != null && secondCard != null)
            roundIsOver = true;
    }

    private void RevealCard(Card card)
    {
        card.GetComponent<SpriteRenderer>().sprite = card.CardFace;
    }
    
    private void StoreCardChoice(Card card)
    {
        if (firstCard == null)
            firstCard = card;
        else if (secondCard == null)
            secondCard = card;
    }

    private void EvaluateRoundResult()
    {
        if (firstCard.CardFace.ToString() == secondCard.CardFace.ToString())
        {
            Debug.Log("its a pair!");
            firstCard.gameObject.SetActive(false);
            secondCard.gameObject.SetActive(false);
            MatchMade.Invoke();
        }
            
        else
        {
            firstCard.GetComponent<SpriteRenderer>().sprite = Card.CardBack;
            secondCard.GetComponent<SpriteRenderer>().sprite = Card.CardBack;
            Debug.Log("no pair");
            Mismatch.Invoke();
        }
        roundIsOver = true;
    }

    private void CleanupRound()
    {
        firstCard = null;
        secondCard = null;
        roundIsOver = false;
    }
}
