using UnityEngine;
using System.Collections;

public class PlayerId : MonoBehaviour {

  public int id;
  public bool isSet = false;

  void Start() {
    id = PhotonNetwork.player.ID;
    isSet = true;
  }

}
