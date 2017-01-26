using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

    // Define A Static GameController
    public static GameController control;

    // MonoBehavior Awake
    void Awake()
    {
        // Set control to this Object
        control = this;    
    }
	// Use this for initialization
	void Start ()
    {
        // Load Level 01
        StartCoroutine(LoadLevel("Level01"));
	}
	
    // Load A Scene, pass SceneName
    public IEnumerator LoadLevel(string sceneName)
    {
        // wait until the end of the current frame
        yield return new WaitForEndOfFrame();
        // Load the Scene Asyncrosonusly
        SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);
        // Unload Previous Scenes
        StartCoroutine(UnLoadLevels(sceneName));
        
    }
	
    // Unload All levels except the current level in the scene.
    private IEnumerator UnLoadLevels(string exception)
    {
        // Wait until The end of the current frame.
        yield return new WaitForEndOfFrame();
        // for each scene that is currently loaded
        for (int i = 0; i < SceneManager.sceneCount; i++)
        {   
            // Check to see if the scene is not an exception nor the current scene
            if(SceneManager.GetSceneAt(i).name != exception && SceneManager.GetSceneAt(i).name != "VRMain")
            {
                // If not the loaded scene unload scene.
                SceneManager.UnloadScene(SceneManager.GetSceneAt(i).name);
            }
            
        }
    }
}
