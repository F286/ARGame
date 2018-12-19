using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// May need to copy this to top line of CameraCapture.mm to fix xCode Error
// #define STATIC_ARRAY_COUNT(arr) sizeof(arr)/sizeof(arr[0])

public class Setup : MonoBehaviour {

  [Header("Fixed camera mode in editor instead of Vuforia")]
  public bool useEditorMode = true;
  [Space]
  public GameObject ar;
  public GameObject editor;
  
  public void Awake() {
    if (Application.isEditor && useEditorMode) {
      ar.SetActive(false);
      editor.SetActive(true);
    }
    else {
      ar.SetActive(true);
      editor.SetActive(false);
    }
  }
}
