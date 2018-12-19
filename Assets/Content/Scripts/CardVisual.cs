using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardVisual : MonoBehaviour, IDragInteractTarget {

  int lastUpdatedTurn = -1;

  public Card card;

  [Space]
  public Text text;

  public void Update() {
    if (CardData.instance.IsDirty(ref lastUpdatedTurn)) {

      var count = 0;

      foreach (var item in CardData.instance.GetCards()) {
        if (item.position == card.position && item.type == card.type) {
          count += 1;
        }
      }
      text.text = count.ToString();
    }
  }

  public CardPosition GetPosition() {
    return card.position;
  }

  public int GetPlayerIndex() {
    if (card.position == CardPosition.Player1Share || 
        card.position == CardPosition.Player1Toolbox) {
      return 1;
    }
    else if ( card.position == CardPosition.Player2Share || 
              card.position == CardPosition.Player2Toolbox) {
      return 2;
    }
    return 0;
  }
}
