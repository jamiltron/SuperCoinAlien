using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class ScrollableList : MonoBehaviour {
  public GameObject roomPrefab;
  public RectTransform containerRectTransform;

  //private RectTransform prefabTransform;
  private List<GameObject> roomListings;
  
  void Start() {
    //prefabTransform = roomPrefab.GetComponent<RectTransform>();
    roomListings = new List<GameObject>();
  }

  public void DisplayRooms(RoomInfo[] rooms) {
    foreach (var room in roomListings) {
      Destroy(room);
    }
    roomListings.Clear();

    int i = 0;
    foreach (var room in roomListings) {
      GameObject newRoom = Instantiate(roomPrefab) as GameObject;
      newRoom.name = room.name + " room";
      newRoom.transform.SetParent(gameObject.transform);
      
      RectTransform roomTransform = newRoom.GetComponent<RectTransform>();
      float width = roomTransform.rect.width;
      float height = roomTransform.rect.height;
      
      float x = -containerRectTransform.rect.width / 2;
      float y = containerRectTransform.rect.height / 2 - height * i - height;
      roomTransform.offsetMin = new Vector2(x, y);
      
      x = roomTransform.offsetMin.x + width;
      y = roomTransform.offsetMin.y + height;
      roomTransform.offsetMax = new Vector2(x, y);

      roomListings.Add(newRoom);
      i += 1;
    }

  }
  
}