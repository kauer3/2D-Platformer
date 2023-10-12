using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    private static bool created = false;
    public string titleScene;
    public string levelSelectScene;
    public bool isPaused;
    public GameObject pauseCanvas;

    private void Awake()
    {
        if (!created)
        {
            DontDestroyOnLoad(gameObject);
            created = true;
            Debug.Log("New LevelManager created.");
        }
        else
        {
            Debug.Log("LevelManager already exists, destroying...");
            Destroy(gameObject);
        }
    }

    void Update()
    {
        if (isPaused)
        {
            pauseCanvas.SetActive(true);
            Time.timeScale = 0f;
        }
        else
        {
            pauseCanvas.SetActive(false);
            Time.timeScale = 1f;
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isPaused = !isPaused;
        }
    }

    public void LevelSelect()
    {
        SceneManager.LoadSceneAsync(levelSelectScene);
        if (isPaused) isPaused = false;
    }

    public void QuitToMenu()
    {
        SceneManager.LoadSceneAsync(titleScene);
        if (isPaused) isPaused = false;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
