using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Robot : MonoBehaviour {
  // public Vector2Int position;
  // public Vector2Int direction = new Vector2Int(1, 0);

  public float animateSpeed = 0.2f;
  Vector2 velocity;

  public void Update() {
    // Animate robot to target position
    var p = new Vector2(transform.localPosition.x, transform.localPosition.z);
    p = Vector2.SmoothDamp(p, BoardData.instance.GetRobotPosition(), ref velocity, animateSpeed);
    transform.localPosition = new Vector3(p.x, transform.localPosition.y, p.y);
  }

  public void OnInteract() {
    BoardData.instance.SetRobotPosition();
  }

}
