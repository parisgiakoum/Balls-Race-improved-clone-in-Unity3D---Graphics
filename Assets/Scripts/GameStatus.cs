using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;


public class GameStatus : MonoBehaviour {

    public GameObject positionText;
    public GameObject prefixText;
    public GameObject playerNumText;
    public GameObject percentageText;
    public GameObject[] players;

    public static float[] position;
    public static int current;
    public static int percentage;
    private int previous;
    private GameObject player;
    private bool changedPrefix;
    private bool changedPercentage;

    private float totalDistance;
    private float distanceCovered;

	// Use this for initialization
	void Start () {
        position = new float[players.Length];
        findCurrent();
        previous = current;
        positionText.GetComponent<Text>().text = "" + current;
        prefixText.GetComponent<Text>().text = findPrefix(current);
        positionText.GetComponent<Animator>().speed = 0;
        prefixText.GetComponent<Animator>().speed = 0;
        playerNumText.GetComponent<Text>().text = "" + players.Length;

        percentageText.GetComponent<Text>().text = "0";
    }

    // Update is called once per frame
    void Update () {

        findCurrent();
        if (previous != current)
        {
            StartCoroutine(changePosition());
        }
        previous = current;

        percentage = findPerecentage();
        percentageText.GetComponent<Text>().text = "" + percentage;
    }

    void findCurrent()
    {
       
        for (int i = 0; i < players.Length; i++)
        {
            position[i] = players[i].transform.position.z;
            if (players[i].CompareTag("Player"))
            {
                player = players[i];
            }
        }

        Array.Sort(position);

        for (int i = 0; i < position.Length; i++)
        {
            if (player.transform.position.z == position[i])
            {
                current = position.Length - i;
            }
        }
    }

    public static String findPrefix(int number)
    {
        if ((number >= 1 && number <= 3) || number > 20)
        {
            if (number % 10 == 1)
            {
                return "st";
            }
            else if (number % 10 == 2)
            {
                return "nd";
            }
            else if (number % 10 == 3)
            {
                return "rd";
            }
            else
            {
                return "th";
            }
        }
        else
        {
            return "th";
        }
    }
    
    int findPerecentage()
    {
        totalDistance = Mathf.Abs(FinishTrack.finishZ - PlayerController.startPos);
        distanceCovered = Mathf.Abs(player.transform.position.z - PlayerController.startPos);
        return (int)((distanceCovered / totalDistance) * 100);
    }

    IEnumerator changePosition()
    {
        positionText.GetComponent<Animator>().speed = 1;
        if (prefixText.GetComponent<Text>().text != findPrefix(current))
        {
            prefixText.GetComponent<Animator>().speed = 1;
            changedPrefix = true;
        }
        else
        {
            changedPrefix = false;
        }
        
        yield return new WaitForSeconds(1f);

        positionText.GetComponent<Text>().text = "" + current;
        positionText.GetComponent<Animator>().speed = 0;
        if (changedPrefix)
        {
            prefixText.GetComponent<Text>().text = findPrefix(current);
            prefixText.GetComponent<Animator>().speed = 0;
        }
        
    }

   

}
