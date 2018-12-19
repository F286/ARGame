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

      Vector3 min = Vector3.zero;
      Vector3 max = Vector3.zero;

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
        var p = new Vector3(block.position.x, 0, block.position.y);
        copy.transform.localPosition = p;
        copy.SetActive(true);
        if (visual) {
          visual.card = new Card(block.player, index, Symbol.None, Location.Block);
          visual.Clean();
        }

        min = Vector3.Min(min, p);
        max = Vector3.Max(max, p);

        index += 1;
      }

      transform.localPosition = Vector3.Scale(transform.localScale, (min + max) / -2f);

    }
  }

}
