using UnityEngine;
using System.Collections;

public class SpawnCoin : MonoBehaviour {

  public CoinGrabber coinGrabber;
  public GameObject coinPrefab;
  public GameObject[] spawnPoints;
  

  void Awake() {
    if (coinGrabber != null) {
      coinGrabber.OnCoinGrabbedEvent += GenerateCoin;
    }
  }

  public void GenerateCoin(Vector3 lastPosition) {
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
    Instantiate(coinPrefab, newPosition, Quaternion.identity);
  }

}
