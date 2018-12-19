using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class Gesture : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler {

  public Color color = Color.black;
  public UnityEvent onInteract;

  float lastTapTime = -100;

  public void Start() {
    GetComponent<Renderer>().material = GameObject.Instantiate(GetComponent<Renderer>().material);
    color = GetComponent<Renderer>().material.color;
  }

  public void OnPointerClick(PointerEventData eventData) {

    if (Time.time - lastTapTime < 0.3f) {
      onInteract.Invoke();
    }

    lastTapTime = Time.time;
  }

  public void OnPointerEnter(PointerEventData eventData) {

    if (color != Color.black) {
      GetComponent<Renderer>().material.color = Color.Lerp(color, Color.black, 0.1f);
    }
  }

  public void OnPointerExit(PointerEventData eventData) {
    
    if (color != Color.black) {
      GetComponent<Renderer>().material.color = color;
    }
  }
  
}
