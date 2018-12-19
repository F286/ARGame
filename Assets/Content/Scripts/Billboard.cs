using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour {
  void LateUpdate() {
    var d = transform.position - Camera.main.transform.position;
    transform.eulerAngles = new Vector3(0, Mathf.Atan2(d.x, d.z) * Mathf.Rad2Deg, 0);
  }
}
