using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardVisual : MonoBehaviour, ICardTarget {

  int lastUpdatedTurn = -1;

  public Card card;

  [Space]
  public Text text;
  public GameObject number;

  public void Update() {
    if (CardData.instance.IsDirty(ref lastUpdatedTurn)) {

      var count = 0;

      foreach (var item in CardData.instance.GetCards()) {
        if (item == card) {
          count += 1;
        }
      }
      text.text = count.ToString();
      number.SetActive(count > 0);

      GetComponent<Button>().interactable = count > 0;
      GetComponent<DragInteract>().enabled = count > 0;

    }
  }

  public Card GetCard() {
    return card;
  }
}
