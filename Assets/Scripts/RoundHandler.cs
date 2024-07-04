using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RoundHandler : MonoBehaviour
{
    private Card _firstCard;
    private Card _secondCard;
    private bool _roundIsOver;
    private static int _cardTracker;
     
    [CanBeNull] public static event Action MatchMade;
    [CanBeNull] public static event Action Mismatch;
    [CanBeNull] public static event Action GameEnded;
    
    
    void Start()
    {
        Card.CardClicked += OnCardClicked;
        _cardTracker = GameGrid.CardAmount;
        _roundIsOver = false;
        _firstCard = null;
        _secondCard = null;
    }

    private void OnCardClicked(Card card)
    {
        if (_roundIsOver)
        {
            CheckGameEnd();
            CleanupRound();
            return;
        }
            
        if (card.CardWasPicked)
            return;

        if (!_roundIsOver)
        {
            RevealCard(card);
            StoreCardChoice(card);
        }

        if (_firstCard != null && _secondCard != null)
        {
            _roundIsOver = true;
            EvaluateRoundResult(); 
        }
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
        
        card.CardWasPicked = true;
    }

    private void EvaluateRoundResult()
    {
        if (_firstCard.CardFace.ToString() == _secondCard.CardFace.ToString())
        {
            if (MatchMade != null)
                MatchMade.Invoke();
            _cardTracker -= 2;
        }
            
        else
        {
            if (Mismatch != null)
                Mismatch.Invoke();
        }
        
        _roundIsOver = true;
    }

    private void CleanupRound()
    {
        if (_firstCard.CardFace.ToString() == _secondCard.CardFace.ToString())
        {
            _firstCard.gameObject.SetActive(false);
            _secondCard.gameObject.SetActive(false);
        }
            
        else
        {
            _firstCard.GetComponent<SpriteRenderer>().sprite = Card.CardBack;
            _secondCard.GetComponent<SpriteRenderer>().sprite = Card.CardBack;
        }
        
        _firstCard.CardWasPicked = false;
        _firstCard = null;

        _secondCard.CardWasPicked = false;
        _secondCard = null;
        
        _roundIsOver = false;
    }

    private void CheckGameEnd()
    {
        if (_cardTracker != 0)
            return; 
        
        if (GameEnded != null)
            GameEnded.Invoke();
        Card.CardClicked -= OnCardClicked;
        SceneManager.LoadScene(2);
    }
}
