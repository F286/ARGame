using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragInteract : MonoBehaviour, IInitializePotentialDragHandler, IBeginDragHandler, IDragHandler, IEndDragHandler {

  public RectTransform graphic;

  public void OnInitializePotentialDrag(PointerEventData eventData) {
    
  }
  public void OnBeginDrag(PointerEventData eventData) {
    GetComponent<CanvasGroup>().blocksRaycasts = false;

    graphic.position = eventData.position;
  }

  public void OnDrag(PointerEventData eventData) {
    graphic.position = eventData.position;
  }

  public void OnEndDrag(PointerEventData eventData) {
    
    graphic.anchoredPosition = Vector2.zero;

    var hovered = eventData.hovered == null || 
                 eventData.hovered.Count == 0 ? 
                    null : eventData.hovered[0];
    var hoveredCard = hovered == null ? null : hovered.GetComponentInParent<ICardTarget>();

    print(hovered);
    print(hoveredCard);
    if (hoveredCard != null) {
      var target = hoveredCard.GetCard();
      var self = GetComponent<ICardTarget>().GetCard();

      print(self);
      print(target);

      if (self.player == target.player) {
        CardData.instance.SetCard(self, new Card(self.player, target.blockIndex, self.symbol, target.location));
      }

    //   var cardTarget = GetComponent<ICardTarget>();
    //   var cardPosition = cardTarget.GetPosition();
    //   var cardType = cardTarget.GetCardType();

    //   var position = hovered.GetPosition();

    //   if ((int)position > 0) {
    //     CardData.instance.SetCard(cardPosition, cardType, position);
    //   }
    //   else if ( position == CardPosition.Player1Share || 
    //             position == CardPosition.Player2Share || 
    //             position == CardPosition.Player1Toolbox || 
    //             position == CardPosition.Player2Toolbox) {
        
    //     CardData.instance.SetCard(cardPosition, cardType, position);
    //   }
    }

    GetComponent<CanvasGroup>().blocksRaycasts = true;
  }

}
