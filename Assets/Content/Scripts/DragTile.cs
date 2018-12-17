using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragTile : MonoBehaviour, IInitializePotentialDragHandler, IBeginDragHandler, IDragHandler, IEndDragHandler {

  public RectTransform graphic;

  public void OnInitializePotentialDrag(PointerEventData eventData) {
    
  }
  public void OnBeginDrag(PointerEventData eventData) {
    graphic.position = eventData.position;
  }

  public void OnDrag(PointerEventData eventData) {
    graphic.position = eventData.position;
  }

  public void OnEndDrag(PointerEventData eventData) {
    
    // graphic.sizeDelta = Vector2.zero;
    graphic.anchoredPosition = Vector2.zero;
  }

}
