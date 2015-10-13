using UnityEngine;
using System.Collections;

public class OfflineModeStarter : MonoBehaviour {

  public GameObject spawners;

  void Start() {
    PhotonNetwork.offlineMode = true;
    PhotonNetwork.CreateRoom("Offline Room");
    GameObject coinSpawner = PhotonNetwork.InstantiateSceneObject("CoinSpawner", Vector3.zero, Quaternion.identity, 0, new object[0]);
    GameObject slimeSpawner = PhotonNetwork.InstantiateSceneObject("SlimeSpawner", new Vector3(0f, 4.6f, 0f), Quaternion.identity, 0, new object[0]);
    coinSpawner.transform.parent = spawners.transform;
    slimeSpawner.transform.parent = spawners.transform;
  }

}
