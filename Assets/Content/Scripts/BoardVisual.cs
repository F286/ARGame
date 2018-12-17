using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardVisual : MonoBehaviour {

  int lastUpdatedTurn = -1;

  public void Update() {
    if (BoardData.instance.IsDirty(ref lastUpdatedTurn)) {

    }
  }

  // public Vector2Int robotPosition;
  
  // [Space]
  // public GameObject robot;

  // public 
}
