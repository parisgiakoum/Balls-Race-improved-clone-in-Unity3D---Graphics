using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    private int currentCam;
    public GameObject[] cameras;
    public GameObject player;
    private Vector3[] dist;
    public GameObject LostMenu;
    public GameObject InfoPanel;
    public GameObject Rank;
    public static bool lost = false;

	// Use this for initialization
	void Start () {
        dist = new Vector3[cameras.Length];
        currentCam = 0;
        for (int i = 0; i <cameras.Length; i++)
        {
            dist[i] = cameras[i].transform.position - transform.position;
        }
        lost = false;
    }
	
	// Update is called once per frame
	void Update () {
        transform.position = player.transform.position;
        for (int i = 0; i < cameras.Length; i++)
        {
            cameras[i].transform.position = transform.position + dist[i];
        }

        if (Input.GetKeyDown("c"))
        {
            cameras[currentCam].SetActive(false);
            if (currentCam < cameras.Length - 2)
            {
                currentCam++;
            }
            else
            {
                currentCam = 0;
            }
            cameras[currentCam].SetActive(true);
        }
        if (Input.GetButton("BackCam"))
        {
            cameras[currentCam].SetActive(false);
            cameras[cameras.Length - 1].SetActive(true);
        }
        else
        {
            cameras[currentCam].SetActive(true);
        }

        if (lost)
        {
            InfoPanel.SetActive(false);
            Rank.SetActive(false);
            StartCoroutine(LostActions());
        }

	}

    IEnumerator LostActions()
    {
        yield return new WaitForSeconds(3);
        LostMenu.SetActive(true);
    }
}
