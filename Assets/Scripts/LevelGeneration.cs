using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGeneration : MonoBehaviour {

    public GameObject[] objects;
    
	// Use this for initialization
	void Start () {
        int rand = Random.Range(0, objects.Length);
        Instantiate(objects[rand], new Vector3(objects[rand].transform.position.x, objects[rand].transform.position.y, transform.position.z), Quaternion.identity);
	}
	
}
