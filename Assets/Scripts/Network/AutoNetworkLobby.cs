using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class AutoNetworkLobby : MonoBehaviour {

  public Text statusLabel;

  private enum AutoState {
    Starting,
    JoinedLobby,
    CreatingRoom,
    JoiningRoom,
    JoinedRoom,
    StartingGame,
    Failed
  }

  private AutoState state = AutoState.Starting;

  public void StopLobby() {
    if (PhotonNetwork.room != null) {
      PhotonNetwork.LeaveRoom();
    }
  }


  void Start() {
    PhotonNetwork.ConnectUsingSettings("v1.0");
    statusLabel.text = "Joining lobby...";
  }

  void OnFailedToConnectToPhoton() {
    statusLabel.text = "Failed to connect, try later.";
    state = AutoState.Failed;
  }

  void OnJoinedLobby() {
    Debug.Log("OnJoinedLobby");
    state = AutoState.JoinedLobby;
    statusLabel.text = "Searching for a game...";

    JoinRandomRoom();
  }

  void OnPhotonRandomJoinFailed() {
    Debug.Log("OnPhotonRandomJoinFailed!");
    statusLabel.text = "Creating Game";
    state = AutoState.CreatingRoom;
    RoomOptions options = new RoomOptions() { isOpen = true, isVisible = true, maxPlayers = 2};
    PhotonNetwork.CreateRoom(null, options, null);
  }

  void JoinRandomRoom() {
    Debug.Log("JoinRandomRoom");
    if (state == AutoState.JoinedLobby) {
      Debug.Log("JoinRandomRoom -> state == JoinedLobby");
      state = AutoState.JoiningRoom;
      PhotonNetwork.JoinRandomRoom();
      Debug.Log("Trying PhotonNetwork.JoinRandomRoom()");
    }
  }

  void OnJoinRoomFailed() {
    Debug.Log("OnJoinRoomFailed");
  }

  void OnJoinedRoomFailed() {
    Debug.Log("OnJoinRoomFailed");
    statusLabel.text = "Creating Game";
    state = AutoState.CreatingRoom;
    RoomOptions options = new RoomOptions() { isOpen = true, isVisible = true, maxPlayers = 2};
    PhotonNetwork.CreateRoom(null, options, null);
  }

  void OnJoinRoom() {
    Debug.Log("on join room!");
  }

  void OnJoinedRoom() {
    Debug.Log("OnJoinedRoom");
    state = AutoState.JoinedRoom;

    StartCoroutine("WaitForPlayers");
  }

  void OnPhotonCreateRoomFailed() {
    state = AutoState.Failed;
    statusLabel.text = "Failed to create a game, try later.";
  }

  IEnumerator WaitForPlayers() {
    while (PhotonNetwork.room != null) {
      int maxPlayers = PhotonNetwork.room.maxPlayers;
      int currPlayers = PhotonNetwork.room.playerCount;
      
      if (currPlayers < maxPlayers) {
        statusLabel.text = "Waiting on " + (maxPlayers - currPlayers).ToString() + " players.";
      } else {
        state = AutoState.StartingGame;
        statusLabel.text = "Starting game";
        PhotonNetwork.LoadLevel("OnlineGameScene");
        break;
      }
      yield return null;
    }
  }

}
