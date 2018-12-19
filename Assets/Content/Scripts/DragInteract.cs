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

    ICardTarget cardTarget = null;
    foreach (var item in eventData.hovered) {
      var find = item.GetComponent<ICardTarget>();
      if (find != null) {
        cardTarget = find;
        break;
      }
    }
    if (cardTarget != null) {
      var target = cardTarget.GetCard();
      var self = GetComponent<ICardTarget>().GetCard();

      // print(self);
      // print(target);

      if (self.player == target.player) {
        CardData.instance.SetCard(self, new Card(self.player, target.blockIndex, self.symbol, target.location));
      }
    }

    GetComponent<CanvasGroup>().blocksRaycasts = true;
  }

}
