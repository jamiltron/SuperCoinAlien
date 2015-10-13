using UnityEngine;
using System.Collections;

public class SceneChanger : MonoBehaviour {

  public void LoadOfflineScene(string sceneName) {
    PhotonNetwork.offlineMode = true;
    PhotonNetwork.CreateRoom("Offline Game");
    Application.LoadLevel(sceneName);
  }

  public void LoadScene(string sceneName) {
    Application.LoadLevel(sceneName);
  }

}
