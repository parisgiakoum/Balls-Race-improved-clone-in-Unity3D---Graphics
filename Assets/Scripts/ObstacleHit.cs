using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleHit : MonoBehaviour {

    private AudioSource[] hit;

    // Use this for initialization
    private void OnCollisionEnter(Collision collision)
    {
        hit = gameObject.GetComponents<AudioSource>();
        gameObject.transform.GetChild(0).gameObject.GetComponent<ParticleSystem>().Play();
        gameObject.transform.GetChild(1).gameObject.GetComponent<ParticleSystem>().Play();
        collision.gameObject.SetActive(false);
        hit[1].Play();
        if (collision.gameObject.tag == "Player")
        {
            hit[0].Play();
            CameraController.lost = true;
            LostMenu.lostPos = GameStatus.current;
        }
    }

}
