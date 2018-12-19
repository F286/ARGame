using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class Gesture : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler {

  public UnityEvent onInteract;
  
  Color? color = null;

  public void OnPointerClick(PointerEventData eventData) {

    print(eventData.clickCount);
    if (eventData.clickCount == 2) {
      onInteract.Invoke();
    }
  }

  public void OnPointerEnter(PointerEventData eventData) {
    if (!color.HasValue) {
      color = GetComponent<Renderer>().material.color;
    }
    GetComponent<Renderer>().material.color = Color.Lerp(color.Value, Color.black, 0.1f);
  }

  public void OnPointerExit(PointerEventData eventData) {
    if (!color.HasValue) {
      color = GetComponent<Renderer>().material.color;
    }
    GetComponent<Renderer>().material.color = color.Value;
  }
}
