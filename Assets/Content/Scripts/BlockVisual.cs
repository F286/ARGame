using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlockVisual : MonoBehaviour, ICardTarget {

  int lastUpdatedTurn = -1;

  public Card card;

  [Space]
  public GameObject billboard;
  public GameObject[] templates;
  public Material[] materials;

  public void Awake() {
    foreach (var item in templates) {
      item.SetActive(false);
    }
    billboard.SetActive(false);
  }

  public void Update() {
    if (CardData.instance.IsDirty(ref lastUpdatedTurn)) {
      Clean(false);
    }
  }

  public void Clean(bool manualClean = true) {
    if (manualClean) {
      CardData.instance.IsDirty(ref lastUpdatedTurn);
    }

    foreach (Transform item in billboard.transform) {
      if (item.name == "[COPY]") {
        Destroy(item.gameObject);
      }
    }

    var setBillboardActive = false;

    var types = new List<Symbol>();
    foreach (var item in CardData.instance.GetCards()) {
      if (item.blockIndex == card.blockIndex && 
          item.location == card.location) {
        types.Add(item.symbol);
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

    if (card.player >= 0 && card.player < materials.Length) {
      GetComponent<MeshRenderer>().material = materials[card.player];
    }
  }

  public Card GetCard() {
    return card;
  }

}
