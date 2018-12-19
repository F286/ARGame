using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class Gesture : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler {

  public Color color = Color.black;
  public UnityEvent onInteract;

  public void Start() {
    GetComponent<Renderer>().material = GameObject.Instantiate(GetComponent<Renderer>().material);
    color = GetComponent<Renderer>().material.color;
  }
  
  // Color? color = null;

  public void OnPointerClick(PointerEventData eventData) {

    // print(eventData.clickCount);
    if (eventData.clickCount == 2) {
      onInteract.Invoke();
    }
  }

  public void OnPointerEnter(PointerEventData eventData) {
    // ValidateColor();

    if (color != Color.black) {
      GetComponent<Renderer>().material.color = Color.Lerp(color, Color.black, 0.1f);
    }
  }

  public void OnPointerExit(PointerEventData eventData) {
    
    if (color != Color.black) {
      GetComponent<Renderer>().material.color = color;
    }
  }

  // void ValidateColor() {
  //   // Color is set before material can be assigned.. add delay ?
  //   if (color == Color.black) {
  //     // GetComponent<Renderer>().material = GameObject.Instantiate(GetComponent<Renderer>().material);
  //     // color = GetComponent<Renderer>().material.color;
  //   }
  // }
}
