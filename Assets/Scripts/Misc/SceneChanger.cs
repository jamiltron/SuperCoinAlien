using UnityEngine;
using System.Collections;

public class SceneChanger : MonoBehaviour {

  public void LoadScene(string sceneName) {
    Application.LoadLevel(sceneName);
  }

}
