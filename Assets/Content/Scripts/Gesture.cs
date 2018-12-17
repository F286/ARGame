using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class Gesture : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerClickHandler {

  public Color color = Color.white;

  public UnityEvent onInteract;

  public void OnPointerClick(PointerEventData eventData) {
    print(eventData.pointerCurrentRaycast.worldPosition);

    onInteract.Invoke();
  }

  public void OnPointerDown(PointerEventData eventData) {
    GetComponent<Renderer>().material.color = Color.Lerp(color, Color.black, 0.1f);
  }

  public void OnPointerUp(PointerEventData eventData) {
    GetComponent<Renderer>().material.color = color;
  }

  // public void OnValidate() {
  //   GetComponent<Renderer>().sharedMaterial.color = color;
  // }
}
