using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {
  public float bulletSpeed = 3f;

  private float x;

  public void Shoot(float normalizedX) {
    if (Mathf.Approximately(normalizedX, 0f)) {
      this.x = 0f;
    } else if (normalizedX < 0f) {
      this.x = -1f;
    } else if (normalizedX > 0f) {
      this.x = 1f;
    }
  }

  void Update() {
    transform.Translate(new Vector3(bulletSpeed * x * Time.deltaTime, 0f, 0f));
  }

  void OnBecameInvisible() {
    Destroy(this.gameObject);
  }

}
