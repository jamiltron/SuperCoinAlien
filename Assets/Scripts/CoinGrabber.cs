using UnityEngine;
using System;
using System.Collections;

[RequireComponent(typeof(CharacterController2D))]
public class CoinGrabber : MonoBehaviour {

  public int coins = 0;
  public event Action<Vector3> OnCoinGrabbedEvent;
  private CharacterController2D controller;

  void Awake() {
    controller = GetComponent<CharacterController2D>();
    controller.onTriggerEnterEvent += OnTriggerEnterEvent;
  }

  void OnTriggerEnterEvent(Collider2D col) {
    if (col.gameObject.tag == "Coin") {
      if (OnCoinGrabbedEvent != null) {
        OnCoinGrabbedEvent(col.gameObject.transform.position);
      }
      coins += 1;
      Destroy(col.gameObject);
    }
  }

}
