using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShareVisual : MonoBehaviour, ICardTarget {

  int lastUpdatedTurn = -1;

  public Card card;
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
      
      GetComponent<Button>().interactable = card.symbol != Symbol.None;
      GetComponent<DragInteract>().enabled = card.symbol != Symbol.None;
    }
  }

  public Card GetCard() {
    return card;
  }
}
