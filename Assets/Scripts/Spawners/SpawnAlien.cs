using UnityEngine;
using System.Collections;

[RequireComponent(typeof(PlayerId))]
public class SpawnAlien : MonoBehaviour {
  public Transform player1Spawner;
  public Transform player2Spawner;

  private PlayerId playerId;

  void Start() {
    playerId = GetComponent<PlayerId>();
    StartCoroutine("Spawn");
  }

  IEnumerator Spawn() {
    // TODO: allow this to support more than 2 players
    while (playerId == null || !playerId.isSet) {
      yield return null;
    }

    GameObject alien;
    if (playerId.id < PhotonNetwork.otherPlayers[0].ID) {
      Debug.Log("Spawning player 1");
      alien = PhotonNetwork.Instantiate("GreenAlien", player1Spawner.position, Quaternion.identity, 0);
      if (alien == null) {
        Debug.LogError("Was unable to instantiate alien 1");
      }
    } else if (playerId.id > PhotonNetwork.otherPlayers[0].ID) {
      Debug.Log("Spawning player 2");
      alien = PhotonNetwork.Instantiate("PinkAlien", player2Spawner.position, Quaternion.identity, 0);
      if (alien == null) {
        Debug.LogError("Was unable to instantiate alien 2");
      }
    } else {
      Debug.LogError("Players have same ID!");
    }
    //OwnerId ownerId = alien.GetComponent<OwnerId>();
    //ownerId.ownerId = playerId.id;
  }
}
