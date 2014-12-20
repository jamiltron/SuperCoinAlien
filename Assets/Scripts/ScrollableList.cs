using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class ScrollableList : MonoBehaviour {
  public GameObject roomPrefab;

  
  
  void Start() {
    //RectTransform roomRectTransform = roomPrefab.GetComponent<RectTransform>();
    RectTransform containerRectTransform = gameObject.GetComponent<RectTransform>();
        
    for (int i = 0; i < 1; i++) {
      GameObject newRoom = Instantiate(roomPrefab) as GameObject;
      newRoom.name = gameObject.name + i;
      newRoom.transform.parent = gameObject.transform;

      RectTransform roomTransform = newRoom.GetComponent<RectTransform>();
      float width = roomTransform.rect.width;
      float height = roomTransform.rect.height;

      float x = -containerRectTransform.rect.width / 2;
      float y = containerRectTransform.rect.height / 2 - height * i - height;
      roomTransform.offsetMin = new Vector2(x, y);

      x = roomTransform.offsetMin.x + width;
      y = roomTransform.offsetMin.y + height;
      roomTransform.offsetMax = new Vector2(x, y);
    }
    
    
  }
  
}