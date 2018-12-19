using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShareSimulate : MonoBehaviour {

  int lastUpdatedTurn = -1;

  public float animationDelay = 0.3f;

  [Space]
  public ShareVisual player0;
  public ShareVisual player1;

  public void Update() {
    if (CardData.instance.IsDirty(ref lastUpdatedTurn)) {

      StopAllCoroutines();

      StartCoroutine(PlayAsync());
    }
  }

  IEnumerator PlayAsync() {
    var data = CardData.instance;

    yield return new WaitForSeconds(animationDelay);
    
    if (player0.card.symbol != Symbol.None && player1.card.symbol != Symbol.None) {
      data.SetCard(player0.card, 
        new Card(1, player0.card.blockIndex, player0.card.symbol, Location.Toolbox));
      data.SetCard(player1.card, 
        new Card(0, player1.card.blockIndex, player1.card.symbol, Location.Toolbox));
    }
  }

}
