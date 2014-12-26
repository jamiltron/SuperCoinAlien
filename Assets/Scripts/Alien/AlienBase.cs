using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AlienInput), typeof(AlienDisplay), typeof(AlienMovement))]
public class AlienBase : Photon.MonoBehaviour {

  private AlienInput input;
  private AlienDisplay display;
  private AlienMovement movement;

  void Awake() {
    input = GetComponent<AlienInput>();
    display = GetComponent<AlienDisplay>();
    movement = GetComponent<AlienMovement>();
  }

  void Update() {
    input.GetInput();
  }

  void FixedUpdate() {
    movement.Move();
  }

  void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info) {
    if (stream.isWriting) {
      SerializeInput();
    } else {
      DeserializeInput();
    }
  }

  void SerializeInput() {
    // no-op
  }

  void DeserializeInput() {
    // no-op
  }

}
