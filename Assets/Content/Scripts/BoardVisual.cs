using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardVisual : MonoBehaviour {

  int lastUpdatedTurn = -1;

  public GameObject robot;
  public GameObject start;
  public GameObject middle;
  public GameObject end;

  [Space]
  public GameObject generated;

  public void Update() {
    if (CardData.instance.IsDirty(ref lastUpdatedTurn)) {
      
      start.SetActive(false);
      middle.SetActive(false);
      end.SetActive(false);

      foreach (Transform item in generated.transform) {
        Destroy(item.gameObject);
      }

      // Generate the board
      var index = 0;
      foreach (var block in CardData.instance.GetBlocks()) {

        // Pick which template to use
        var template = middle;
        if (block.player == -1) {
          template = start;
        }
        else if (block.player == 2) {
          template = end;
        }

        var copy = GameObject.Instantiate(template, generated.transform);
        var visual = copy.GetComponent<BlockVisual>();
        if (visual) {
          visual.card = new Card(block.player, index, Symbol.None, Location.Block);
        }
        copy.transform.localPosition = new Vector3(block.position.x, 0, block.position.y);
        copy.SetActive(true);

        index += 1;
      }
    }
  }

}
