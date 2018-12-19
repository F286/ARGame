using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchPlayer : MonoBehaviour {

  public bool isPlayerOne = true;

  public GameObject[] playerOne;
  public GameObject[] playerTwo;

  public void Start() {
    SetPlayer();
  }

  public void OnInteract() {
    isPlayerOne = !isPlayerOne;
    SetPlayer();
  }

  public void SetPlayer() {
    foreach (var item in playerOne) {
      item.SetActive(isPlayerOne);
    }
    foreach (var item in playerTwo) {
      item.SetActive(!isPlayerOne);
    }
  }
}
