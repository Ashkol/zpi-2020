using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    SceneIndexes currentScene = SceneIndexes.MASTER;

    void Start()
    {
        LoadMainMenu();
    }

    public void LoadScene(int sceneIndex)
    {
        SceneManager.LoadSceneAsync(sceneIndex, LoadSceneMode.Additive);
        SceneManager.UnloadSceneAsync((int)currentScene);
        currentScene = (SceneIndexes)sceneIndex;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) )
        {
            LoadMainMenu();
        }

    }

    private void LoadMainMenu()
    {
        if (currentScene != SceneIndexes.MASTER)
        {
            SceneManager.UnloadSceneAsync((int)currentScene);
        }
        SceneManager.LoadSceneAsync((int)SceneIndexes.MAIN_MENU, LoadSceneMode.Additive);
        currentScene = SceneIndexes.MAIN_MENU;
    }
}
