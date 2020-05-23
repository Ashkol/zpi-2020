using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class MainMenuInteractiveObject : MonoBehaviour
{
    GameManager gameManager;

    public UnityEvent OnMouseDownEvent;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    private void OnMouseDown()
    {
        OnMouseDownEvent.Invoke();
        //gameManager.LoadScene((int)SceneIndexes.GAME);
    }

    public void LoadScene(int sceneIndex)
    {
        gameManager.LoadScene(sceneIndex);
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
        // Application.Quit() does not work in the editor so
        // UnityEditor.EditorApplication.isPlaying need to be set to false to end the game
        UnityEditor.EditorApplication.isPlaying = false;
#else
         Application.Quit();
#endif
    }
}
