using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class Card : MonoBehaviour
{
  [SerializeField] private Sprite cardBackSprite;
   public Sprite CardFace { get; set; }
   public static Sprite CardBack;
   public static event Action<Card> CardClicked;
   private SpriteRenderer _spriteRenderer;
   public Vector3 CardScale { get; set; }
   public bool CardWasPicked { get; set; }

   private void Start()
   {
       CardBack = cardBackSprite;
       _spriteRenderer = GetComponent<SpriteRenderer>();
       _spriteRenderer.sprite = CardBack;
       CardWasPicked = false;
       //CardScale = new Vector3(1, 1, 1);
       //transform.localScale = CardScale;
   }
   
   private void OnMouseUpAsButton()
   {
       if (CardClicked != null) 
           CardClicked.Invoke(this);
   }
}
