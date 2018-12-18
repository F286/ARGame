using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotSimulate : MonoBehaviour {

  public float animationDelay = 0.3f;

  public void Play() {
    StopAllCoroutines();


  }

  IEnumerator PlayAsync() {

    // CardData.instance.

    yield return new WaitForSeconds(animationDelay);
  }
}
