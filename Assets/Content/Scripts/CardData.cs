using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardData : MonoBehaviour {

  int currentTurn = 0;
  
  [SerializeField] Vector2Int robotPosition = new Vector2Int();
  [SerializeField] Vector2Int robotDirection = new Vector2Int(1, 0);

  [SerializeField] List<Tile> board = new List<Tile>();
  [SerializeField] List<Card> cards = new List<Card>();

  public Vector2Int GetRobotPosition() {
    return robotPosition;
  }
  public Vector2Int GetRobotDirection() {
    return robotDirection;
  }
  public List<Tile> GetBoard() {
    return board;
  }
  public List<Card> GetCards() {
    return cards;
  }
  public CardPosition GetCardPosition(Vector2Int boardPosition) {
    for (int i = 0; i < board.Count; i++) {
      if (boardPosition == board[i].board) {
        return (CardPosition)i;
      }
    }
    return CardPosition.Invalid;
  }


  public void SetCard(CardPosition cardPosition, CardType cardType, CardPosition setTo) {
    foreach (var item in cards) {
      if (item.type == cardType && item.position == cardPosition) {
        item.position = setTo;

        SetDirty();
        return;
      }
    }
    Debug.Assert(false, "Could not find card: " + cardPosition + ", " + cardType);
  }
  public void SetRobotPosition(Vector2Int target) {
    robotPosition = target;
  }
  public void SetRobotDirection(Vector2Int target) {
    robotDirection = target;
  }

  public bool IsDirty(ref int lastTurn) {
    var isDirty = currentTurn != lastTurn;
    lastTurn = currentTurn;
    return isDirty;
  }
  void SetDirty() {
    currentTurn += 1;
  }

  static CardData _instance;
  public static CardData instance {
    get {
      if (_instance == null) {
        _instance = GameObject.FindObjectOfType<CardData>();
      }
      return _instance;
    }
  }
}
[System.Serializable]
public class Tile {
  public Vector2Int board;
  public int playerIndex;
}
[System.Serializable]
public class Card {
  public CardPosition position;
  public CardType type;
}
public enum CardPosition {
  Player1Toolbox = -500,
  Player2Toolbox = -499,
  Player1Share = -400,
  Player2Share = -399,
  Invalid = -300,
  Tile0 = 0,
  Tile1 = 1,
  Tile2 = 2,
  Tile3 = 3,
  Tile4 = 4,
  Tile5 = 5,
  Tile6 = 6,
  Tile7 = 7,
  Tile8 = 8,
  Tile9 = 9,
  Tile10 = 10,
  Tile11 = 11,
  Tile12 = 12,
  Tile13 = 13,
  Tile14 = 14,
  Tile15 = 15,
}
public enum CardType {
  Invalid,
  Forward,
  Left,
  Right,
}