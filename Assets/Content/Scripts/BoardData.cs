using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardData : MonoBehaviour {
  
  [SerializeField] Vector2Int robotPosition = new Vector2Int();
  [SerializeField] Vector2Int robotDirection = new Vector2Int(1, 0);
  [SerializeField] List<TileData> board = new List<TileData>();

  [SerializeField] MoveData[] players = new MoveData[2];
  [SerializeField] MoveData shared = new MoveData();

  public Vector2Int GetRobotPosition() {
    return robotPosition;
  }

  public void SetRobotPosition() {
    robotPosition += robotDirection;
  }

  static BoardData _instance;
  public static BoardData instance {
    get {
      if (_instance == null) {
        _instance = GameObject.FindObjectOfType<BoardData>();
      }
      return _instance;
    }
  }
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