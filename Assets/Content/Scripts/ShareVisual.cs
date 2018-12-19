﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShareVisual : MonoBehaviour, ICardTarget {

  int lastUpdatedTurn = -1;

  public Card card;
  // public CardPosition position;
  public GameObject[] graphics;

  public void Update() {
    if (CardData.instance.IsDirty(ref lastUpdatedTurn)) {

      foreach (var item in graphics) {
        item.SetActive(false);
      }

      card = new Card(card.player, card.blockIndex, Symbol.None, card.location);

      foreach (var item in CardData.instance.GetCards()) {
        if (item.location == card.location && item.player == card.player) {
          card = new Card(card.player, card.blockIndex, item.symbol, card.location);
        }
      }

      // Set Graphic
      graphics[(int)card.symbol].SetActive(true);

      // var cardType = FindCardType();
      
      // graphics[(int)cardType].SetActive(true);
    }
  }
  // CardType FindCardType() {
  //   CardType? cardType = null;

  //   foreach (var item in CardData.instance.GetCards()) {
  //     if (item.position == position) {
  //       cardType = item.type;
  //     }
  //   }

  //   if (cardType.HasValue) {
  //     return cardType.Value;
  //   }
  //   else {
  //     return CardType.Invalid;
  //   }
  // }

  // public CardPosition GetPosition() {
  //   return position;
  // }
  // public CardType GetCardType() {
  //   return FindCardType();
  // }
  // public int GetPlayerIndex() {
  //   return CardTarget.CalculatePlayerIndex(position);
  // }

  public Card GetCard() {
    return card;
  }
}
