using UnityEngine;
using System;
using System.Collections;

[RequireComponent(typeof(CharacterController2D))]
public class CoinGrabber : MonoBehaviour {

  public int coinsGrabbed = 0;
  public AudioSource coinSound;

  private CharacterController2D controller;
  private SpawnCoin coinSpawner;

  void Awake() {
    controller = GetComponent<CharacterController2D>();
    controller.onTriggerEnterEvent += OnTriggerEnterEvent;
    coinSpawner = GameObject.FindGameObjectWithTag("CoinSpawner").GetComponent<SpawnCoin>();
  }

  void OnTriggerEnterEvent(Collider2D col) {
    Debug.Log("Trigger!");
    if (col.gameObject.tag == "Coin") {
      coinSound.Play();
      if (coinSpawner == null) {
        Debug.LogError("Spawner is null!");
      } else {
        coinSpawner.GenerateCoin();
      }
      coinsGrabbed += 1;
    }
  }

}
