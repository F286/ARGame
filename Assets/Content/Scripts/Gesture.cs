using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class Gesture : MonoBehaviour, IPointerClickHandler {

  public void OnPointerClick(PointerEventData eventData) {
    print(eventData.pointerCurrentRaycast.worldPosition);

    GetComponent<MeshRenderer>().material.color = Color.red;
  }

}
