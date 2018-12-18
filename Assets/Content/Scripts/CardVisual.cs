using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardVisual : MonoBehaviour {

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

}
