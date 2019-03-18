using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockTracks : MonoBehaviour {

    public static bool isUnlocked;
    public GameObject locker;

    public void Update()
    {
        if (isUnlocked)
        {
            locker.SetActive(false);
        }
        else
        {
            locker.SetActive(true);
        }
    }

}
