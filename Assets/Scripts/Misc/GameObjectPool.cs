using UnityEngine;
using System.Collections.Generic;

public class GameObjectPool {
  private Stack<GameObject> objects;
  private string prefab;

  public GameObjectPool(string prefab) {
    this.prefab = prefab;
    objects = new Stack<GameObject>();
  }

  public GameObject Get(Vector3 position) {
    if (objects.Count == 0) {
      return PhotonNetwork.InstantiateSceneObject(prefab, position, Quaternion.identity, 0, new object[0]);
      //return (GameObject) GameObject.Instantiate(prefab, position, Quaternion.identity);
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
