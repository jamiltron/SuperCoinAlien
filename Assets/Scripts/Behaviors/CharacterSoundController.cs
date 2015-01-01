using UnityEngine;
using System.Collections;

[RequireComponent(typeof(CharacterController2D))]
public class CharacterSoundController : MonoBehaviour {

  public AudioSource jumpSound;
  public AudioSource headHitSound;
  public AudioSource groundHitSound;

  private CharacterController2D controller;

  void Awake() {
    controller = GetComponent<CharacterController2D>();
  }


	void Update () {
    if (controller.isGrounded && Input.GetButtonDown("Jump"))
    {
      jumpSound.Play();
    }

    if (controller.collisionState.becameGroundedThisFrame) {
      groundHitSound.Play();
    }

    if (!controller.isGrounded && controller.collisionState.above) {
      headHitSound.Play();
    }
	}
}
