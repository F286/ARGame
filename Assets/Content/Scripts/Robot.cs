using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Robot : MonoBehaviour {
  // public Vector2Int position;
  // public Vector2Int direction = new Vector2Int(1, 0);

  public float animateSpeed = 0.2f;
  public float animateAngularSpeed = 0.2f;
  Vector2 velocity;
  float angularVelocity;

  public void Update() {
    // Animate robot to target position
    var p = new Vector2(transform.localPosition.x, transform.localPosition.z);
    p = Vector2.SmoothDamp(p, CardData.instance.GetRobotPosition(), ref velocity, animateSpeed);
    transform.localPosition = new Vector3(p.x, transform.localPosition.y, p.y);

    // Animate robot to target rotation
    var a = transform.eulerAngles.y;
    var direction = CardData.instance.GetRobotDirection();
    a = Mathf.SmoothDampAngle(a, -Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg, ref angularVelocity, animateAngularSpeed);
    transform.localRotation = Quaternion.Euler(0, a, 0);
  }

  public void OnInteract() {
    // CardData.instance.SetRobotPosition();
  }

}
