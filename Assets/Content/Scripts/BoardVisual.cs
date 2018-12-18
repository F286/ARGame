﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardVisual : MonoBehaviour {

  int lastUpdatedTurn = -1;

  public GameObject robot;
  public GameObject start;
  public GameObject middle;
  public GameObject end;

  [Space]
  public GameObject generated;

  public void Update() {
    if (BoardData.instance.IsDirty(ref lastUpdatedTurn)) {
      // print("update board visual");
      start.SetActive(false);
      middle.SetActive(false);
      end.SetActive(false);

      foreach (Transform item in generated.transform) {
        Destroy(item.gameObject);
      }

      // Generate the board
      var boardData = BoardData.instance.GetBoard();
      for (int i = 0; i < boardData.Count; i++) {
        var item = boardData[i];

        // Pick which template to use
        var template = middle;
        if (i == 0) {
          template = start;
        }
        else if (i == boardData.Count - 1) {
          template = end;
        }

        var copy = GameObject.Instantiate(template, generated.transform);
        copy.transform.localPosition = new Vector3(item.x, 0, item.y);
        copy.SetActive(true);
      }
    }
  }

}
