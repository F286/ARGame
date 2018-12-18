using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotSimulate : MonoBehaviour {

  public float animationDelay = 0.3f;

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
  }

  IEnumerator ActivateTile() {
    var data = CardData.instance;

    var position = data.GetCardPosition(data.GetRobotPosition());

    if (position == CardPosition.Invalid) {
      print("Robot is off grid");
    }
    
    foreach (var item in data.GetCards()) {
      if (item.position == position && item.type == CardType.Left) {
        var d = data.GetRobotDirection();
        d = new Vector2Int(-d.y, d.x);
        data.SetRobotDirection(d);

        yield return new WaitForSeconds(animationDelay);
      }
    }
    
    foreach (var item in data.GetCards()) {
      if (item.position == position && item.type == CardType.Right) {
        var d = data.GetRobotDirection();
        d = new Vector2Int(d.y, -d.x);
        data.SetRobotDirection(d);

        yield return new WaitForSeconds(animationDelay);
      }
    }

    foreach (var item in data.GetCards()) {
      if (item.position == position && item.type == CardType.Forward) {
        data.SetRobotPosition(data.GetRobotPosition() + data.GetRobotDirection());

        yield return new WaitForSeconds(animationDelay);

        yield return ActivateTile();
      }
    }

  }

}
