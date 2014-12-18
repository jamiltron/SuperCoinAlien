using UnityEngine;
using System.Collections;

[RequireComponent(typeof(CharacterController2D))]
public class CharacterInputController : MonoBehaviour {
  public float gravity = -25f;
  public float runSpeed = 8f;
  public float groundDamping = 20f; // how fast do we change direction? higher means faster
  public float inAirDamping = 5f;
  public float jumpHeight = 3f;
  
  [HideInInspector]
  private float normalizedHorizontalSpeed = 0;
  
  private CharacterController2D _controller;
  private CharacterAnimationController _animator;
  private RaycastHit2D _lastControllerColliderHit;
  private Vector3 _velocity;
  
  void Awake() {
    _animator = GetComponent<CharacterAnimationController>();
    _controller = GetComponent<CharacterController2D>();
  }
  
  // the Update loop contains a very simple example of moving the character around and controlling the animation
  void Update() {
    if (Input.GetButton("Quit")) {
      Application.Quit();
    }

    // grab our current _velocity to use as a base for all calculations
    _velocity = _controller.velocity;
    
    if(_controller.isGrounded) {
      _velocity.y = 0;
    }
    
    if(Input.GetButton("Right")) {
      normalizedHorizontalSpeed = 1;
      if(transform.localScale.x < 0f) {
        transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
      }
    } else if (Input.GetButton("Left")) {
      normalizedHorizontalSpeed = -1;
      if (transform.localScale.x > 0f) {
        transform.localScale = new Vector3( -transform.localScale.x, transform.localScale.y, transform.localScale.z);
      }
    } else {
      normalizedHorizontalSpeed = 0;
    }
    
    
    // we can only jump whilst grounded
    if( _controller.isGrounded && Input.GetButtonDown("Jump"))
    {
      _velocity.y = Mathf.Sqrt(2f * jumpHeight * -gravity);
    }
    
    
    // apply horizontal speed smoothing it
    var smoothedMovementFactor = _controller.isGrounded ? groundDamping : inAirDamping; // how fast do we change direction?
    _velocity.x = Mathf.Lerp( _velocity.x, normalizedHorizontalSpeed * runSpeed, Time.deltaTime * smoothedMovementFactor );
    
    // apply gravity before moving
    _velocity.y += gravity * Time.deltaTime;
    
    _controller.move(_velocity * Time.deltaTime);
    if (_animator != null) {
      _animator.AnimateBasedOnMovement(normalizedHorizontalSpeed, _velocity.y * Time.deltaTime, _controller.isGrounded);
    }
  }
  
}