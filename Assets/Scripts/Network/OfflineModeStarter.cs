using UnityEngine;
using System.Collections;

public class OfflineModeStarter : MonoBehaviour {

  void Start() {
    PhotonNetwork.offlineMode = true;
  }

}
