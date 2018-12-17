using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class ARManager : MonoBehaviour {
  public bool hasPlaced = false;

  [Space]
  public ContentPositioningBehaviour contentPositioningBehaviour;

  public void Awake() {
    VuforiaRuntime.Instance.InitVuforia();
  }

  public void OnInteractiveHitTest(HitTestResult result) {
    // print("interactive: " + result.Position);
    if (!hasPlaced) {
      hasPlaced = true;
      contentPositioningBehaviour.PositionContentAtPlaneAnchor(result);
      contentPositioningBehaviour.gameObject.SetActive(false);
    }
  }

  public void OnAutomaticHitTest(HitTestResult result) {
    // print("automatic: " + result.Position);
    
  }

}
