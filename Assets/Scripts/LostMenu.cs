using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LostMenu : MonoBehaviour {

    public static int lostPos;
    public GameObject positionText;
    public GameObject prefix;
    public GameObject percentageText;
    public GameObject players;

    public void PlayAgain()
    {
        Time.timeScale = 1;
        LevelChanger.sceneToLoad = SceneManager.GetActiveScene().buildIndex;
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
        positionText.GetComponent<Text>().text = "" + lostPos;
        prefix.GetComponent<Text>().text = GameStatus.findPrefix(lostPos);
        if (GameStatus.percentage < 100)
        {
            percentageText.GetComponent<Text>().text = "" + GameStatus.percentage;
        }
        else
        {
            percentageText.GetComponent<Text>().text = "100";
        }
        
        players.GetComponent<Text>().text = "" + GameStatus.position.Length;
    }
}
