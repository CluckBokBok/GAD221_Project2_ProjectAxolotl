using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{

    // NOTE - not case sensitive
    public void LoadSceneByName(string sceneName) //  function that changes the scene based on the scene name entered
    {
        Debug.Log("Loading [" + sceneName + "] scene");
        SceneManager.LoadScene(sceneName); // change the scene
    }

    public void LoadSceneByNumber(int sceneNum) // simple function that changes scene by the number entered
    {
        Debug.Log("Loading scene [" + sceneNum + "]");
        SceneManager.LoadScene(sceneNum); // change the scene
    }

    public void QuitTheGame() // quits the application
    {
        Application.Quit(); // quit game
        Debug.Log("Quit Game (theoretically)");
    }

}
