using UnityEngine;
using System.Collections;

/// <summary>
/// Reads in player input, decides if it is legal or not, and updates fields
/// for other classes to read regarding movement, animation, etc.
/// Currently only really validates jumping, but will be useful in the 
/// case of duck-jumping through one-way platforms, ledge grabbing, etc.
/// </summary>
[RequireComponent(typeof(AlienMovement))]
public class AlienInput : Photon.MonoBehaviour {

  private AlienMovement movement;

  public bool jumpPressed = false;
  public bool leftPressed = false;
  public bool rightPressed = false;

  void Awake() {
    movement = GetComponent<AlienMovement>();
  }

  public void GetInput() {
    // if we aren't offline and we don't own this entity bail out
    if (!PhotonNetwork.offlineMode && !photonView.isMine) {
      return;
    }

    // exit if we see the quit button
    if (Input.GetButton("Quit")) {
      Application.Quit();
    }

    // handle the jump button
    if (movement.IsGrounded() && Input.GetButton("Jump")) {
      jumpPressed = true;
    } else {
      jumpPressed = false;
    }

    if (Input.GetButton("Left")) {
      leftPressed = true;
    } else {
      leftPressed = false;
    }

    if (Input.GetButton("Right")) {
      rightPressed = true;
    } else {
      leftPressed = false;
    }
  }

}
