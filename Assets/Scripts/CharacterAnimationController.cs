using UnityEngine;
using System.Collections;

[RequireComponent(typeof(tk2dSpriteAnimator))]
public class CharacterAnimationController : MonoBehaviour {

  private tk2dSpriteAnimator _animator;

  public float jumpingThreshold = 0.07f;
  public Transform normalGunPosition;
  public Transform jumpingGunPosition;
  public GameObject gun;

  void Awake() {
    _animator = GetComponent<tk2dSpriteAnimator>();
  }

  public void AnimateBasedOnMovement(float xMovement, float yMovement, bool isGrounded) {
    if (Mathf.Approximately(xMovement, 0) && 
        isGrounded &&
        !_animator.IsPlaying("Idle")) {
      gun.transform.position = normalGunPosition.position;
      _animator.Play("Idle");
    } else if (yMovement >= jumpingThreshold || yMovement <= -jumpingThreshold) {
      gun.transform.position = jumpingGunPosition.position;
      _animator.Play("Jump");
    } else if (!Mathf.Approximately(xMovement, 0) && isGrounded) {
      gun.transform.position = normalGunPosition.position;
      _animator.Play("Walk");
    } 
  }
}
