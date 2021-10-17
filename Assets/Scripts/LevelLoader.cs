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
        Start
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

    public void LoadStartScene()
    {
        currentSceneIndex = (int)Scene.Start;
        SceneManager.LoadScene((int)Scene.Start);
    }

    public void LoadNextScene()
    {
        SceneManager.LoadScene(++currentSceneIndex);
    }
}
