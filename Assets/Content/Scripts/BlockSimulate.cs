using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSimulate : MonoBehaviour {

  public void ResetBlock() {
    var card = GetComponent<ICardTarget>().GetCard();

    foreach (var item in CardData.instance.GetCards()) {
      if (item.blockIndex == card.blockIndex && 
          item.location == card.location) {
        CardData.instance.SetCard(item, new Card(item.player, 0, item.symbol, Location.Toolbox));
      }
    }
  }

}
