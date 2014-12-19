using UnityEngine;
using System.Collections;

[RequireComponent(typeof(CharacterController2D), typeof(BoxCollider2D))]
public class WalkAndBumpBehavior : MonoBehaviour {
  public float gravity = -25f;
  public float walkSpeed = 8f;
  public float groundDamping = 20f; // how fast do we change direction? higher means faster
  public bool facingRight = false;

  private CharacterController2D controller;
  private BoxCollider2D col;
  private float normalizedHorizontalSpeed = 0f;
  private Vector3 velocity;


  void Awake() {
    controller = GetComponent<CharacterController2D>();
    col = GetComponent<BoxCollider2D>();
    controller.onControllerCollidedEvent += HandleOnControllerCollidedEvent;
  }

  void Update() {
    velocity = controller.velocity;
    
    if(controller.isGrounded) {
      velocity.y = 0;
    }

    
    if(facingRight && controller.isGrounded) {
      normalizedHorizontalSpeed = 1;
    } else if (!facingRight && controller.isGrounded) {
      normalizedHorizontalSpeed = -1;
    } else {
      normalizedHorizontalSpeed = 0;
    }

    velocity.x = Mathf.Lerp(velocity.x, normalizedHorizontalSpeed * walkSpeed, Time.deltaTime * groundDamping);
    
    // apply gravity before moving
    velocity.y += gravity * Time.deltaTime;

    controller.move(velocity * Time.deltaTime);
  }

  private void HandleOnControllerCollidedEvent(RaycastHit2D hit) {
    if (hit.normal.x != 0f) {
      TurnAround();

    }

   /* Debug.Log(hit.normal.x + " , " + hit.normal.y);
    Debug.Log("Collided!");
    if (facingRight) {
      if (hit.
      if (Mathf.Approximately(hit.normal.y, 0f)) {
        Debug.Log("Turning around!");
        TurnAround();
      }
    } else {
      if (Mathf.Approximately(hit.normal.y, 0f)) {
        Debug.Log("turning around!");
        TurnAround();
      }
    }*/
  }

  private void TurnAround() {
    facingRight = !facingRight;

    Vector3 tempScale = transform.localScale;
    tempScale.x *= -1;
    transform.localScale = tempScale;
  }
}