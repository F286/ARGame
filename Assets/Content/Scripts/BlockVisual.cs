using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlockVisual : MonoBehaviour {

  int lastUpdatedTurn = -1;

  public CardPosition position;

  [Space]
  public GameObject billboard;
  public GameObject[] templates;

  public void Awake() {
    foreach (var item in templates) {
      item.SetActive(false);
    }
    billboard.SetActive(false);
  }

  public void Update() {
    if (CardData.instance.IsDirty(ref lastUpdatedTurn)) {

      foreach (Transform item in billboard.transform) {
        if (item.name == "[COPY]") {
          Destroy(item.gameObject);
        }
      }

      var setBillboardActive = false;

      foreach (var item in CardData.instance.GetCards()) {
        if (item.position == position) {
          var copy = GameObject.Instantiate(templates[(int)item.type], billboard.transform);
          copy.name = "[COPY]";
          copy.SetActive(true);

          setBillboardActive = true;
        }
      }

      billboard.SetActive(setBillboardActive);
    }
  }

}
