using UnityEngine;
using System.Collections.Generic;

public class GameObjectPool {
  private Stack<GameObject> objects;
  private GameObject prefab;

  public GameObjectPool(GameObject prefab) {
    this.prefab = prefab;
    objects = new Stack<GameObject>();
  }

  public GameObject Get(Vector3 position) {
    if (objects.Count == 0) {
      return (GameObject) GameObject.Instantiate(prefab, position, Quaternion.identity);
    } else {
      GameObject obj = objects.Pop();
      obj.transform.position = position;
      obj.SetActive(true);
      return obj;
    }
  }

  public void Dispose(GameObject obj) {
    obj.SetActive(false);
    objects.Push(obj);
  }
}
