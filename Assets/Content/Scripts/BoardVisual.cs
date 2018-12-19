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
      var blocks = new List<Block>();
      foreach (var item in CardData.instance.GetBlocks()) {
        blocks.Add(item);
      }

      for (int i = 0; i < blocks.Count; i++) {
        var block = blocks[i];

        // Pick which template to use
        var template = middle;
        if (i == 0) {
          template = start;
        }
        else if (i == blocks.Count - 1) {
          template = end;
        }

        var copy = GameObject.Instantiate(template, generated.transform);
        copy.GetComponent<BlockVisual>().card = new Card(block.player, i, Symbol.None, Location.Block);
        copy.transform.localPosition = new Vector3(block.position.x, 0, block.position.y);
        copy.SetActive(true);
      }
    }
  }

}
