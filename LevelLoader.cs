using UnityEngine;
using System.Collections;

public class LevelLoader : MonoBehaviour {

    public void LoadLevel(string sceneToLoad)
    {
        // Loads Level
        StartCoroutine(GameController.control.LoadLevel(sceneToLoad));
    }
}
