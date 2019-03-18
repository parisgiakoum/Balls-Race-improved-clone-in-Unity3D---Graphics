using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinishTrack : MonoBehaviour {

    public GameObject player;
    public GameObject Won;
    public GameObject InfoPanel;
    public GameObject Rank;
    public static float finishZ;
    public static bool isFinished;
    private AudioSource[] finishMusic;
    private AudioSource LevelMusic;
    private int finishPos;

    // Use this for initialization
    void Start () {
        finishZ = transform.position.z;
        finishMusic = gameObject.GetComponents<AudioSource>();
        LevelMusic = player.gameObject.GetComponent<AudioSource>();
        isFinished = false;
    }

    private void Update()
    {
        if ((Mathf.Abs(player.transform.position.z) - Mathf.Abs(transform.position.z)) <= 100)
        {
            LevelMusic.volume = LevelMusic.volume - 0.02f;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isFinished = true;
            finishPos = GameStatus.current;
            if (finishPos == 1)
            {
                LevelMusic.Pause();
                finishMusic[1].Play();
                WonMenu.wonPos = 1;
                InfoPanel.SetActive(false);
                Rank.SetActive(false);
                StartCoroutine(WonActions());
            }
            else
            {
                LevelMusic.Pause();
                finishMusic[0].Play();

                CameraController.lost = true;
                LostMenu.lostPos = GameStatus.current;
            }
        }
        

    }

    IEnumerator WonActions()
    {
        yield return new WaitForSeconds(5);
        Won.SetActive(true);
    }


}
