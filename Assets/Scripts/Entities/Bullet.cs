using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {
  public float bulletSpeed = 3f;

  private float x;
  private RaycastHit2D hit;
  private GameObject owningGun;
  private GameObject owningAlien;
  public LayerMask mask;

  public void Shoot(float normalizedX, GameObject owningAlien, GameObject owningGun) {
    if (Mathf.Approximately(normalizedX, 0f)) {
      this.x = 0f;
    } else if (normalizedX < 0f) {
      this.x = -1f;
    } else if (normalizedX > 0f) {
      this.x = 1f;
    }
    this.owningGun = owningGun;
    this.owningAlien = owningAlien;
  }

  void Update() {
    Vector2 dir  = x > 0 ? Vector2.right : -Vector2.right;
    float dist = bulletSpeed * x * Time.deltaTime;
    hit = Physics2D.Raycast(transform.position, dir, dist, mask);
    if (hit.collider != null && hit.collider.gameObject != gameObject && hit.collider.gameObject != owningGun && hit.collider.gameObject != owningAlien) {
      Hit();
    } else {
      transform.Translate(new Vector3(dist, 0f, 0f));
    }
  }

  void OnBecameInvisible() {
    Destroy(this.gameObject);
  }
  void Hit() {
    Destroy(this.gameObject);
  }

}
