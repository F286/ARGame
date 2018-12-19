using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragInteract : MonoBehaviour, IInitializePotentialDragHandler, IBeginDragHandler, IDragHandler, IEndDragHandler {

  public RectTransform graphic;

  // [Space]
  // public CardVisual cardVisual;

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

    var target = eventData.hovered == null || 
                 eventData.hovered.Count == 0 ? 
                    null : eventData.hovered[0];
    Debug.Log(target, target);
    var hovered = target == null ? null : target.GetComponentInParent<ICardTarget>();

    print(hovered);
    if (hovered != null) {
      var cardTarget = GetComponent<ICardTarget>();
      var cardPosition = cardTarget.GetPosition();
      var cardType = cardTarget.GetCardType();

      var position = hovered.GetPosition();

      if ((int)position > 0) {
        CardData.instance.SetCard(cardPosition, cardType, position);
      }
      else if ( position == CardPosition.Player1Share || 
                position == CardPosition.Player2Share || 
                position == CardPosition.Player1Toolbox || 
                position == CardPosition.Player2Toolbox) {
        
        CardData.instance.SetCard(cardPosition, cardType, position);
      }
    }

    GetComponent<CanvasGroup>().blocksRaycasts = true;
  }

}
