using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardData : MonoBehaviour {
  
  public Vector2Int robotPosition = new Vector2Int();
  public Vector2Int robotDirection = new Vector2Int(1, 0);
  public List<TileData> board = new List<TileData>();

  public MoveData[] players = new MoveData[2];
  public MoveData shared = new MoveData();
}
[System.Serializable]
public class TileData {
  public Vector2Int position;
  public MoveData move;
}
[System.Serializable]
public class MoveData {
  public int forward;
  public int left;
  public int right;
}