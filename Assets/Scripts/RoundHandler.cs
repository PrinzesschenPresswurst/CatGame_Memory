using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class RoundHandler : MonoBehaviour
{
    private Card _firstCard;
    private Card _secondCard;
    private bool _roundIsOver = false;
    private int _cardTracker = GameGrid.CardAmount;
    
    [CanBeNull] public static event Action MatchMade;
    [CanBeNull] public static event Action Mismatch;
    
    
    void Start()
    {
        Card.CardClicked += OnCardClicked;
    }

    private void OnCardClicked(Card card)
    {
        Debug.Log("card tracker: " + _cardTracker);
        if (_roundIsOver)
        {
            EvaluateRoundResult();
            CleanupRound();
            return;
        }
        
        RevealCard(card);
        StoreCardChoice(card);
        
        if (_firstCard != null && _secondCard != null)
            _roundIsOver = true;
    }

    private void RevealCard(Card card)
    {
        card.GetComponent<SpriteRenderer>().sprite = card.CardFace;
    }
    
    private void StoreCardChoice(Card card)
    {
        if (_firstCard == null)
            _firstCard = card;
        else if (_secondCard == null)
            _secondCard = card;
    }

    private void EvaluateRoundResult()
    {
        if (_firstCard.CardFace.ToString() == _secondCard.CardFace.ToString())
        {
            Debug.Log("its a pair!");
            _firstCard.gameObject.SetActive(false);
            _secondCard.gameObject.SetActive(false);
            _cardTracker -= 2;
            MatchMade.Invoke();
        }
            
        else
        {
            _firstCard.GetComponent<SpriteRenderer>().sprite = Card.CardBack;
            _secondCard.GetComponent<SpriteRenderer>().sprite = Card.CardBack;
            Debug.Log("no pair");
            Mismatch.Invoke();
        }
        _roundIsOver = true;
    }

    private void CleanupRound()
    {
        if (_cardTracker == 0)
            Debug.Log("game over");
        
        _firstCard = null;
        _secondCard = null;
        _roundIsOver = false;
    }
}
