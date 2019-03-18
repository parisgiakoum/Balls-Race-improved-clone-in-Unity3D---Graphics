using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

    public static bool gameIsPaused = false;
    public GameObject pauseMenuUI;
    public GameObject player;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        player.gameObject.GetComponent<AudioSource>().UnPause();
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1;
        gameIsPaused = false;
    }

    void Pause()
    {
        if (FinishTrack.isFinished == false)
        {
            player.gameObject.GetComponent<AudioSource>().Pause();
            pauseMenuUI.SetActive(true);
            Time.timeScale = 0;
            gameIsPaused = true;
        }
    }

    public void Restart()
    {
        Time.timeScale = 1;
        LevelChanger.sceneToLoad = SceneManager.GetActiveScene().buildIndex;
        LevelChanger.change = true;
    }

    public void LoadMenu()
    {
        Time.timeScale = 1;
        LevelChanger.sceneToLoad = 0;
        LevelChanger.change = true;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
