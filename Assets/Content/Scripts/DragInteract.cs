using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragInteract : MonoBehaviour, IInitializePotentialDragHandler, IBeginDragHandler, IDragHandler, IEndDragHandler {

  public RectTransform graphic;

  [Space]
  public CardVisual cardVisual;

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
    
    // graphic.sizeDelta = Vector2.zero;
    graphic.anchoredPosition = Vector2.zero;

    var hovered = eventData.hovered[0].GetComponentInParent<IDragInteractTarget>();

    Debug.Log(hovered);

    var position = hovered.GetPosition();
    print(position);
    print("cardVisual.card.position: " + cardVisual.card.position);

    if ((int)position > 0) {
      CardData.instance.SetCard(cardVisual.card, position);
    }

    GetComponent<CanvasGroup>().blocksRaycasts = true;
  }

}
