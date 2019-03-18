using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WonMenu : MonoBehaviour
{

    public static int wonPos;
    public GameObject positionText;
    public GameObject prefix;
    public GameObject percentageText;
    public GameObject players;

    public void NextTrack()
    {
        Time.timeScale = 1;
        LevelChanger.sceneToLoad = SceneManager.GetActiveScene().buildIndex + 1;
        LevelChanger.change = true;
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void GotoMenu()
    {
        LevelChanger.sceneToLoad = 0;
        LevelChanger.change = true;
    }

    void Update()
    {
        positionText.GetComponent<Text>().text = "" + wonPos;
        prefix.GetComponent<Text>().text = "ST";
        percentageText.GetComponent<Text>().text = "" + 100;
        players.GetComponent<Text>().text = "" + GameStatus.position.Length;
    }
}
