using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardData : MonoBehaviour {

  int currentTurn = 0;
  
  [SerializeField] Vector2Int robotPosition = new Vector2Int();
  [SerializeField] Vector2Int robotDirection = new Vector2Int(1, 0);
  
  [SerializeField] List<Card> cards = new List<Card>();
  [SerializeField] List<Block> blocks = new List<Block>();

  // [SerializeField] Player[] players = new Player[2];

  // [SerializeField] List<Tile> board = new List<Tile>();
  // [SerializeField] List<Card> cards = new List<Card>();

  public Vector2Int GetRobotPosition() {
    return robotPosition;
  }
  public Vector2Int GetRobotDirection() {
    return robotDirection;
  }

  public IEnumerable<Card> GetCards() {
    foreach (var item in cards) {
      yield return item;
    }
  }
  public IEnumerable<Block> GetBlocks() {
    foreach (var item in blocks) {
      yield return item;
    }
  }
  // public List<Tile> GetBoard() {
  //   return board;
  // }
  // public List<Card> GetCards() {
  //   return cards;
  // }
  public int FindBlockIndex(Vector2Int position) {
    for (int i = 0; i < blocks.Count; i++) {
      if (position == blocks[i].position) {
        return i;
      }
    }
    return -1;
  }
  public void SetCard(Card target, Card setTo) {
    for (int i = 0; i < cards.Count; i++) {
      if (cards[i] == target) {
        cards[i] = setTo;
        
        SetDirty();
        return;
      }
    }
    // foreach (var item in cards) {
    //   if (item.type == cardType && item.position == cardPosition) {
    //     item.position = setTo;

    //     SetDirty();
    //     return;
    //   }
    // }
    Debug.Assert(false, "CardData couldn't find: " + target);
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
public struct Card {
  public int player;
  public int blockIndex;
  public Symbol symbol;
  public Location location;

  public Card(int player, int blockIndex, Symbol symbol, Location location) {
    this.player = player;
    this.blockIndex = blockIndex;
    this.symbol = symbol;
    this.location = location;
  }

  public static bool operator ==(Card c1, Card c2) {
      return c1.Equals(c2);
  }
  public static bool operator !=(Card c1, Card c2) {
    return !c1.Equals(c2);
  }
  public override bool Equals(object obj) {
    if (obj == null || GetType() != obj.GetType()) {
        return false;
    }
    var compare = (Card)obj;

    return compare.player == player && compare.blockIndex == blockIndex &&
            compare.symbol == symbol && compare.location == location;
  }

  public override string ToString() {
    return string.Format("Card - player:{0}, blockIndex:{1}, symbol:{2}, location:{3}", player, blockIndex, symbol, location);
  }
  public override int GetHashCode() {
    return 0;
  }
}
[System.Serializable]
public struct Block {
  public int player;
  public Vector2Int position;
}
public enum Symbol {
  None,
  Forward,
  Left,
  Right,
}
public enum Location {
  Toolbox,
  Share,
  Block,
}

// [System.Serializable]
// public class Player {
//   public List<Vector2Int> board;
//   public List<Card> cards;
// }
// [System.Serializable]
// public class Tile {
//   public Vector2Int board;
//   public int playerIndex;
// }
// [System.Serializable]
// public class Card {
//   public CardPosition position;
//   public CardType type;
// }
// public enum CardPosition {
//   Player1Toolbox = -500,
//   Player2Toolbox = -499,
//   Player1Share = -400,
//   Player2Share = -399,
//   Invalid = -300,
//   Tile0 = 0,
//   Tile1 = 1,
//   Tile2 = 2,
//   Tile3 = 3,
//   Tile4 = 4,
//   Tile5 = 5,
//   Tile6 = 6,
//   Tile7 = 7,
//   Tile8 = 8,
//   Tile9 = 9,
//   Tile10 = 10,
//   Tile11 = 11,
//   Tile12 = 12,
//   Tile13 = 13,
//   Tile14 = 14,
//   Tile15 = 15,
// }
// public enum CardType {
//   Invalid,
//   Forward,
//   Left,
//   Right,
// }