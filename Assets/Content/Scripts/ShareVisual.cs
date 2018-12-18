using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShareVisual : MonoBehaviour {

  int lastUpdatedTurn = -1;

  public Card card;
  public GameObject[] graphics;

  public void Update() {
    if (CardData.instance.IsDirty(ref lastUpdatedTurn)) {

      CardType? cardType = null;

      foreach (var item in CardData.instance.GetCards()) {
        if (item.position == card.position) {
          cardType = item.type;
        }
      }
      foreach (var item in graphics) {
        item.SetActive(false);
      }
      
      if (cardType.HasValue) {
        graphics[(int)cardType.Value + 1].SetActive(true);
      }
      else {
        graphics[0].SetActive(true);
      }
    }
  }

}
