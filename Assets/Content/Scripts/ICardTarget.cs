using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICardTarget {

  CardPosition GetPosition();
  CardType GetCardType();
  int GetPlayerIndex();

}
public static class CardTarget {

  public static int CalculatePlayerIndex(CardPosition position) {
    
    if (position == CardPosition.Player1Share || 
        position == CardPosition.Player1Toolbox) {
      return 1;
    }
    else if ( position == CardPosition.Player2Share || 
              position == CardPosition.Player2Toolbox) {
      return 2;
    }
    return 0;
  }
}
