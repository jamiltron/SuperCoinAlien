using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class NetworkLobby : MonoBehaviour {

  public ScrollableList roomList;

  private enum NetworkState {
    Starting,
    JoiningLobby,
    JoinedLobby
  }

  private NetworkState networkState;
  private RoomInfo[] roomInfo;
   

  void Start() {
    networkState = NetworkState.JoiningLobby;
    PhotonNetwork.ConnectUsingSettings("v1.0");
  }

  void OnFailedToConnectToPhoton() {
    Debug.LogError("Failed to load photon!");
  }

  void OnJoinedLobby() {
    networkState = NetworkState.JoinedLobby;
    
    Debug.Log("Lobby joined!");
  }

  void DisplayLobby() {
    if (networkState == NetworkState.JoinedLobby) {
      roomList.DisplayRooms(PhotonNetwork.GetRoomList());
    }
  }

  public void RefreshRooms() {
    DisplayLobby();
  }

}
