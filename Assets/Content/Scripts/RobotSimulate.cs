﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotSimulate : MonoBehaviour {

  public float animationDelay = 0.3f;
  [Space]
  public GameObject winScreen;

  public void Start() {
    winScreen.SetActive(false);
  }

  public void Play() {
    StopAllCoroutines();

    StartCoroutine(PlayAsync());
  }

  IEnumerator PlayAsync() {
    var data = CardData.instance;

    data.SetRobotPosition(new Vector2Int(0, 0));
    data.SetRobotDirection(new Vector2Int(1, 0));

    yield return new WaitForSeconds(animationDelay);
    
    yield return ActivateTile();

    yield return new WaitForSeconds(animationDelay);
    
    data.SetRobotPosition(new Vector2Int(0, 0));
    data.SetRobotDirection(new Vector2Int(1, 0));
  }

  IEnumerator ActivateTile() {
    var data = CardData.instance;

    var blockIndex = data.FindBlockIndex(data.GetRobotPosition());
    var block = data.FindBlock(blockIndex);

    if (block.player == 2) {
      winScreen.SetActive(true);
    }
    
    foreach (var item in data.GetCards()) {
      if (item.blockIndex == blockIndex && item.symbol == Symbol.Left
          && item.location == Location.Block) {
        var d = data.GetRobotDirection();
        d = new Vector2Int(-d.y, d.x);
        data.SetRobotDirection(d);

        yield return new WaitForSeconds(animationDelay);
      }
    }
    
    foreach (var item in data.GetCards()) {
      if (item.blockIndex == blockIndex && item.symbol == Symbol.Right
          && item.location == Location.Block) {
        var d = data.GetRobotDirection();
        d = new Vector2Int(d.y, -d.x);
        data.SetRobotDirection(d);

        yield return new WaitForSeconds(animationDelay);
      }
    }

    foreach (var item in data.GetCards()) {
      if (item.blockIndex == blockIndex && item.symbol == Symbol.Forward
          && item.location == Location.Block) {
        data.SetRobotPosition(data.GetRobotPosition() + data.GetRobotDirection());

        yield return new WaitForSeconds(animationDelay);

        yield return ActivateTile();
        break;
      }
    }

  }

}
