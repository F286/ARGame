using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDragInteractTarget {

  CardPosition GetPosition();
  int GetPlayerIndex();
}
