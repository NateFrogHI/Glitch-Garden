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
        Game,
        GameOver
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
        LoadScene((int)Scene.Start);
    }

    public void LoadGameScene()
    {
        LoadScene((int)Scene.Game);
    }

    public void LoadGameOverScene()
    {
        LoadScene((int)Scene.GameOver);
    }

    public void LoadNextScene()
    {
        LoadScene(++currentSceneIndex);
    }
}
