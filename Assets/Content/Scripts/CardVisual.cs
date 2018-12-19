using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardVisual : MonoBehaviour, ICardTarget {

  int lastUpdatedTurn = -1;

  public Card card;

  [Space]
  public Text text;

  public void Update() {
    if (CardData.instance.IsDirty(ref lastUpdatedTurn)) {

      var count = 0;

      foreach (var item in CardData.instance.GetCards()) {
        if (item == card) {
          count += 1;
        }
      }
      text.text = count.ToString();
    }
  }

  // public CardPosition GetPosition() {
  //   return card.position;
  // }
  // public CardType GetCardType() {
  //   return card.type;
  // }
  // public int GetPlayerIndex() {
  //   return CardTarget.CalculatePlayerIndex(card.position);
  // }

  public Card GetCard() {
    return card;
  }
}
