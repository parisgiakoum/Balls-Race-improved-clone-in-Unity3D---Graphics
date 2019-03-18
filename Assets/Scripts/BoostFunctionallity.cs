using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoostFunctionallity : MonoBehaviour {

    private float startingPlayerSpeed;
    private int thisBooster;
    private AudioSource boostFX;

    private void Start()
    {
        thisBooster = 0;
    }

    private void OnCollisionEnter(Collision collision)
    {
        boostFX = gameObject.GetComponent<AudioSource>();
        boostFX.Play();
        collision.transform.GetChild(0).gameObject.GetComponent<ParticleSystem>().Play();

        if (collision.gameObject.CompareTag("Player")) {
            startingPlayerSpeed = collision.gameObject.GetComponent<PlayerController>().setSpeed;
            collision.gameObject.GetComponent<PlayerController>().curBooster++;
            thisBooster = collision.gameObject.GetComponent<PlayerController>().curBooster;
            if (startingPlayerSpeed * 2 <= collision.gameObject.GetComponent<PlayerController>().maxSpeed)
            {
                collision.gameObject.GetComponent<PlayerController>().currentSpeed = startingPlayerSpeed * 2;
            }
            else
            {
                collision.gameObject.GetComponent<PlayerController>().currentSpeed = collision.gameObject.GetComponent<PlayerController>().maxSpeed;
            }
            StartCoroutine(boost(collision, startingPlayerSpeed, thisBooster));
        }
        else
        {
            startingPlayerSpeed = collision.gameObject.GetComponent<AIController>().setSpeed;        
            collision.gameObject.GetComponent<AIController>().curBooster++;
            thisBooster = collision.gameObject.GetComponent<AIController>().curBooster;
            if (startingPlayerSpeed * 2 <= collision.gameObject.GetComponent<AIController>().maxSpeed)
            {
                collision.gameObject.GetComponent<AIController>().currentSpeed = startingPlayerSpeed * 2;
            }
            else
            {
                collision.gameObject.GetComponent<AIController>().currentSpeed = collision.gameObject.GetComponent<AIController>().maxSpeed;
            }
            StartCoroutine(boost(collision, startingPlayerSpeed, thisBooster));
        }
        
    }
    
    IEnumerator boost(Collision collision, float startingPlayerSpeed, int thisBooster)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            yield return new WaitForSeconds(5);
            if (thisBooster == collision.gameObject.GetComponent<PlayerController>().curBooster)
            {
                collision.gameObject.GetComponent<PlayerController>().currentSpeed = startingPlayerSpeed;
            }
        }
        else
        {
            yield return new WaitForSeconds(5);
            if (thisBooster == collision.gameObject.GetComponent<AIController>().curBooster)
            {
                collision.gameObject.GetComponent<AIController>().currentSpeed = startingPlayerSpeed;
            }
        }
    }

}
