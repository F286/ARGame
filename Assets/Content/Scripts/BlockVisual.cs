using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlockVisual : MonoBehaviour, IDragInteractTarget {

  int lastUpdatedTurn = -1;

  public CardPosition position;
  public int playerIndex;

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

      var types = new List<CardType>();
      
      foreach (var item in CardData.instance.GetCards()) {
        if (item.position == position) {
          types.Add(item.type);
        }
      }
      types.Sort((a, b) => (int)b - (int)a);

      foreach (var item in types) {
        var copy = GameObject.Instantiate(templates[(int)item], billboard.transform);
        copy.name = "[COPY]";
        copy.SetActive(true);

        setBillboardActive = true;
      }
      

      billboard.SetActive(setBillboardActive);
    }
  }

  public CardPosition GetPosition() {
    return position;
  }
  public int GetPlayerIndex() {
    return playerIndex;
  }
}
