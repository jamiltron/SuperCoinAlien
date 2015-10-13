using UnityEngine;
using System.Collections;

public class TimerBasedSpawner : MonoBehaviour {
  public int secondsBetweenSpawning = 2;
  public bool spawn = true;
  public string slimePrefab;

  private bool spawning = false;
  private GameObjectPool slimePool;
  private Vector3 myPosition;
  private PhotonView photonView;

  void Awake() {
    myPosition = GetComponent<Transform>().position;
    slimePool = new GameObjectPool(slimePrefab);
  }

  void Start() {
    photonView = GetComponent<PhotonView>();
  }

  void FixedUpdate() {
    if (!photonView.isMine) {
      return;
    }

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
