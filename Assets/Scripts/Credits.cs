using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Credits : MonoBehaviour {

    public GameObject mainMenu;
	// Use this for initialization
	void Start () {
        StartCoroutine(BackToMenu());
	}
	
    IEnumerator BackToMenu()
    {
        yield return new WaitForSeconds(48);
        gameObject.SetActive(false);
        mainMenu.SetActive(true);
    }
}
