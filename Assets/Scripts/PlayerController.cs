using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float setSpeed;
    public float currentSpeed;
    public float maxSpeed;

    public int curBooster;

    public float moveHorizontally;
    private Rigidbody rb;
    private float curHorizontalPos;
    private Vector3 Movement;
    public static float startPos;

    public Material[] ballMat;
    public Material[] trailMat;

    public static int ball = 1000;

    // Use this for initialization
    void Start () {
        if (ball != 1000)
        {
            gameObject.GetComponent<Renderer>().material = ballMat[ball];
            gameObject.GetComponent<TrailRenderer>().material = trailMat[ball];
        }

        rb = GetComponent<Rigidbody>();
        curHorizontalPos = 0.0f;
        currentSpeed = setSpeed;
        startPos = transform.position.z;
    }
	
	// Update is called once per frame
	void FixedUpdate()
    {
        Physics.IgnoreLayerCollision(2, 2);
        Movement = new Vector3(0.0f, 0.0f, currentSpeed);
        curHorizontalPos = transform.position.x;

        if (FinishTrack.isFinished == false)
        {
            rb.velocity = Movement;

            float moveHorizontal = Input.GetAxis("Horizontal");
            if (moveHorizontal > 0)
            {
                transform.position = new Vector3(curHorizontalPos + moveHorizontally, transform.position.y, transform.position.z);
            }
            else if (moveHorizontal < 0)
            {
                transform.position = new Vector3(curHorizontalPos - moveHorizontally, transform.position.y, transform.position.z);
            }
        }
        else
        {
            if (rb.velocity.z > 0.1f)
            {
                rb.velocity = rb.velocity * 0.999f;
            }
        }
       
}
}
