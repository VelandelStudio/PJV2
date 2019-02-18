using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Level loader : presents methods to swap scenes
/// </summary>
public class LoaderLVL : MonoBehaviour {

    /// <summary>
    /// Methods to add to a Button to start a new game
    /// </summary>
    public void StartNewGame()
    {
        Debug.Log("Starting New Game");

        StartCoroutine(LoadYourAsyncScene());
    }

    /// <summary>
    /// Swap the scene when loading is finished
    /// </summary>
    /// <returns>null</returns>
    IEnumerator LoadYourAsyncScene()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("StathosScene Sandbox");

        // Wait until the asynchronous scene fully loads
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }
}
