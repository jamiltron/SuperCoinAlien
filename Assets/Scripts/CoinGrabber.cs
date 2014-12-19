﻿using UnityEngine;
using System;
using System.Collections;

[RequireComponent(typeof(CharacterController2D))]
public class CoinGrabber : MonoBehaviour {

  public int coinsGrabbed = 0;
  public event Action<GameObject> OnCoinGrabbedEvent;
  private CharacterController2D controller;

  void Awake() {
    controller = GetComponent<CharacterController2D>();
    controller.onTriggerEnterEvent += OnTriggerEnterEvent;
  }

  void OnTriggerEnterEvent(Collider2D col) {
    Debug.Log("TRIGGERED!");
    if (col.gameObject.tag == "Coin") {
      if (OnCoinGrabbedEvent != null) {
        OnCoinGrabbedEvent(col.gameObject);
      }
      coinsGrabbed += 1;
    }
  }

}
