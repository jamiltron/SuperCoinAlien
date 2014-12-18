using UnityEngine;
using System.Collections;

public class GunInputController : MonoBehaviour {

  public GameObject bullet;
  public Transform gunTransform;
  public Transform parentTransform;
  public float cooldown = 1f;
  private float currentCooldown = 0f;

  void Update() {
    if (currentCooldown <= 0f && Input.GetButton("Fire")) {
      currentCooldown = cooldown;
      GameObject newObject = (GameObject) Instantiate(bullet, gunTransform.position, Quaternion.identity);
      Bullet bulletComponent = newObject.GetComponent<Bullet>();
      bulletComponent.Shoot(parentTransform.localScale.x);
    }

    currentCooldown -= Time.deltaTime;
    if (currentCooldown < 0) {
      currentCooldown = 0;
    }
  }

}
