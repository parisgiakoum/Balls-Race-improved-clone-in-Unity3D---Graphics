using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TrackSelect : MonoBehaviour {

    public GameObject musicHolder;

    public void Track1()
    {
        LevelChanger.sceneToLoad = 1;
        UnlockTracks.isUnlocked = false;
        LevelChanger.change = true;
        musicHolder.GetComponent<AudioSource>().Pause();
    }

    public void Track2()
    {
        LevelChanger.sceneToLoad = 2;
        UnlockTracks.isUnlocked = false;
        LevelChanger.change = true;
        musicHolder.GetComponent<AudioSource>().Pause();
    }

    public void Track3()
    {
        LevelChanger.sceneToLoad = 3;
        UnlockTracks.isUnlocked = false;
        LevelChanger.change = true;
        musicHolder.GetComponent<AudioSource>().Pause();
    }

}
