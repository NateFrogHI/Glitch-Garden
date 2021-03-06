using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    [SerializeField] float delayInSeconds = 4;
    int currentSceneIndex;

    private enum Scene
    {
        Splash,
        Start,
        Options,
        Level1,
        Level2,
        Win
    }

    void Start()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        if (currentSceneIndex == (int)Scene.Splash)
        {
            StartCoroutine(WaitAndLoad());
        }
    }

    IEnumerator WaitAndLoad()
    {
        yield return new WaitForSeconds(delayInSeconds);
        LoadStartScene();
    }

    private void LoadScene(int sceneIndex)
    {
        currentSceneIndex = sceneIndex;
        SceneManager.LoadScene(sceneIndex);
    }

    public void LoadStartScene()
    {
        Time.timeScale = 1;
        LoadScene((int)Scene.Start);
    }

    public void LoadOptionsScene()
    {
        LoadScene((int)Scene.Options);
    }

    public void LoadGameScene()
    {
        LoadScene((int)Scene.Level1);
    }

    public void LoadWinScene()
    {
        LoadScene((int)Scene.Win);
    }

    public void LoadNextScene()
    {
        LoadScene(currentSceneIndex + 1);
    }

    public void ReloadScene()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(currentSceneIndex);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
