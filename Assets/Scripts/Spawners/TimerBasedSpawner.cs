using UnityEngine;
using System.Collections;

public class TimerBasedSpawner : MonoBehaviour {
  public int secondsBetweenSpawning = 2;
  public bool spawn = true;
  public GameObject slimePrefab;

  private bool spawning = false;
  private GameObjectPool slimePool;
  private Vector3 myPosition;

  void Awake() {
    myPosition = GetComponent<Transform>().position;
    slimePool = new GameObjectPool(slimePrefab);
  }

  void FixedUpdate() {
    if (spawn && !spawning) {
      StartCoroutine("SpawnByTimer");
    }
  }

  private IEnumerator SpawnByTimer() {
    spawning = true;
    while (spawn) {
      yield return new WaitForSeconds(secondsBetweenSpawning);
      Spawn();
    }
  }

  private void Spawn() {
    slimePool.Get(myPosition);
  }
}
