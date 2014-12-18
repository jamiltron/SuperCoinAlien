using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpawnCoin : MonoBehaviour {

  public CoinGrabber coinGrabber;
  public GameObject coinPrefab;
  public GameObject[] spawnPoints;
  

  private GameObject coin;

  void Awake() {
    if (coinGrabber != null) {
      coinGrabber.OnCoinGrabbedEvent += GenerateCoin;
    }
  }

  void Start() {
    GenerateCoin((GameObject)Instantiate(coinPrefab, Vector3.zero, Quaternion.identity));
  }

  public void GenerateCoin(GameObject coin) {
    Vector3 lastPosition = coin.transform.position;
    int i = Random.Range(0, spawnPoints.Length);
    Vector3 newPosition = spawnPoints[i].transform.position;

    if (newPosition == lastPosition) {
      i += 1;
      if (i >= spawnPoints.Length) {
        i = 0;
      }
      newPosition = spawnPoints[i].transform.position;
      if (newPosition == lastPosition) {
        Debug.LogError("Cannot find new position!");
      }
    }
    coin.transform.position = newPosition;
  }

}
