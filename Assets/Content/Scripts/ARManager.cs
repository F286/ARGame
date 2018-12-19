using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class ARManager : MonoBehaviour {

  [Space]
  public ContentPositioningBehaviour contentPositioningBehaviour;

  public void Awake() {
    VuforiaRuntime.Instance.InitVuforia();
  }

  public void OnInteractiveHitTest(HitTestResult result) {
    contentPositioningBehaviour.PositionContentAtPlaneAnchor(result);
    contentPositioningBehaviour.gameObject.SetActive(false);
  }

  public void OnAutomaticHitTest(HitTestResult result) {
    
  }

  public void ShowPlace() {
    contentPositioningBehaviour.gameObject.SetActive(true);
  }
}
