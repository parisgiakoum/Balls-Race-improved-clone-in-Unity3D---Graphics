using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIController : MonoBehaviour
{
    public float setSpeed;
    public float currentSpeed;
    public float maxSpeed;

    public int curBooster;

    public float moveHorizontally;

    private Vector3 Movement;
    private Rigidbody rb;
    private float curHorizontalPos;
    private Transform[] hittedObj;
    private bool[] des;

    public Material[] ballMat;
    public Material[] trailMat;
    public static int mat;

    // Use this for initialization
    void Start()
    {
        currentSpeed = setSpeed;
        rb = GetComponent<Rigidbody>();
        curHorizontalPos = transform.position.x;
        des = new bool[7];
        mat = Random.Range(0, 17);
        gameObject.GetComponent<Renderer>().material = ballMat[mat];
        gameObject.GetComponent<TrailRenderer>().material = trailMat[mat];
    }


    void FixedUpdate()
    {
        Physics.IgnoreLayerCollision(2, 2);
        Movement = new Vector3(0.0f, 0.0f, currentSpeed);

        if (FinishTrack.isFinished == false)
        {
            rb.velocity = Movement;
        }
        else
        {
            if (rb.velocity.z > 0.1f)
            {
                rb.velocity = rb.velocity * 0.999f;
            }
        }

        Ray[] ray = new Ray[7];
        RaycastHit[] hit = new RaycastHit[7];
        hittedObj = new Transform[7];
        for (int i = 0; i < ray.Length; i++)
        {
            ray[i] = new Ray(new Vector3(3 * i - 9, transform.position.y, transform.position.z + 50), transform.position);

            // Debug.DrawRay(ray[i].origin, ray[i].direction * 50, Color.cyan);

            des[i] = Physics.Raycast(ray[i], out hit[i], 50);
            if (des[i])
            {
                hittedObj[i] = hit[i].transform;
            }
        }
        if (des[0] || des[1] || des[2] || des[3] || des[4] || des[5] || des[6])
        {
            if ((des[0] == false) || (des[0] && (hittedObj[0].transform.gameObject.tag == "Ramp")))
            {
                if (des[0] && (hittedObj[0].transform.gameObject.tag == "Ramp"))
                {
                    moveBall(0, ray, hittedObj, true);
                }
                else
                {
                    moveBall(0, ray, hittedObj, false);
                }
            }
            else if ((des[3] == false) || (des[3] && (hittedObj[3].transform.gameObject.tag == "Ramp")))
            {
                if (des[3] && (hittedObj[3].transform.gameObject.tag == "Ramp"))
                {
                    moveBall(3, ray, hittedObj, true);
                }
                else
                {
                    moveBall(3, ray, hittedObj, false);
                }
            }
            else if ((des[1] == false) || (des[1] && (hittedObj[1].transform.gameObject.tag == "Ramp")))
            {
                if (des[1] && (hittedObj[1].transform.gameObject.tag == "Ramp"))
                {
                    moveBall(1, ray, hittedObj, true);
                }
                else
                {
                    moveBall(1, ray, hittedObj, false);
                }
            }
            else if ((des[5] == false) || (des[5] && (hittedObj[5].transform.gameObject.tag == "Ramp")))
            {
                if (des[5] && (hittedObj[5].transform.gameObject.tag == "Ramp"))
                {
                    moveBall(5, ray, hittedObj, true);
                }
                else
                {
                    moveBall(5, ray, hittedObj, false);
                }
            }
            else if ((des[6] == false) || (des[6] && (hittedObj[6].transform.gameObject.tag == "Ramp")))
            {
                if (des[6] && (hittedObj[6].transform.gameObject.tag == "Ramp"))
                {
                    moveBall(6, ray, hittedObj, true);
                }
                else
                {
                    moveBall(6, ray, hittedObj, false);
                }
            }
            else if ((des[2] == false) || (des[2] && (hittedObj[2].transform.gameObject.tag == "Ramp")))
            {
                if (des[2] && (hittedObj[2].transform.gameObject.tag == "Ramp"))
                {
                    moveBall(2, ray, hittedObj, true);
                }
                else
                {
                    moveBall(2, ray, hittedObj, false);
                }
            }
            else if ((des[4] == false) || (des[4] && (hittedObj[4].transform.gameObject.tag == "Ramp")))
            {
                if (des[4] && (hittedObj[4].transform.gameObject.tag == "Ramp"))
                {
                    moveBall(4, ray, hittedObj, true);
                }
                else
                {
                    moveBall(4, ray, hittedObj, false);
                }
            }
        }
    }

    void moveBall(int ball, Ray[] ray, Transform[] hittedObj, bool center)
    {
        if (ball == 0)
        {
            if (center == false)
            {
               // transform.position = new Vector3(transform.position.x, 1, transform.position.z);
                if (curHorizontalPos > ray[ball].origin.x + 0.3f)
                {
                    transform.position = new Vector3(transform.position.x - moveHorizontally, transform.position.y, transform.position.z);
                }
                if (transform.position.x >= ray[ball].origin.x - 0.1f && transform.position.x <= ray[ball].origin.x + 0.1f)
                {
                    transform.position = new Vector3(ray[ball].origin.x, transform.position.y, transform.position.z);
                    curHorizontalPos = transform.position.x;
                }
            }
            else
            {
                if (curHorizontalPos > ray[ball].origin.x + 1.8f)
                {
                    transform.position = new Vector3(transform.position.x - moveHorizontally, transform.position.y, transform.position.z);
                }
                if (transform.position.x >= ray[ball].origin.x - 1.4f && transform.position.x <= ray[ball].origin.x + 1.6f)
                {
                    transform.position = new Vector3(ray[ball].origin.x + 1.5f, transform.position.y, transform.position.z);
                    curHorizontalPos = transform.position.x;
                }
            }
        }
        else if (ball == 6)
        {
            if (center == false)
            {
               // transform.position = new Vector3(transform.position.x, 1, transform.position.z);
                if (curHorizontalPos < ray[ball].origin.x - 0.3f)
                {
                    transform.position = new Vector3(transform.position.x + moveHorizontally, transform.position.y, transform.position.z);
                }
                if (transform.position.x >= ray[ball].origin.x - 0.1f && transform.position.x <= ray[ball].origin.x + 0.1f)
                {
                    transform.position = new Vector3(ray[ball].origin.x, transform.position.y, transform.position.z);
                    curHorizontalPos = transform.position.x;
                }
            }
            else
            {
                if (curHorizontalPos < ray[ball].origin.x - 1.8f)
                {
                    transform.position = new Vector3(transform.position.x + moveHorizontally, transform.position.y, transform.position.z);
                }
                if (transform.position.x >= ray[ball].origin.x - 1.4f && transform.position.x <= ray[ball].origin.x + 1.6f)
                {
                    transform.position = new Vector3(ray[ball].origin.x - 1.5f, transform.position.y, transform.position.z);
                    curHorizontalPos = transform.position.x;
                }
            }
        }
        else
        {
            if (center == false)
            {
              //  transform.position = new Vector3(transform.position.x, 1, transform.position.z);
                if (curHorizontalPos > ray[ball].origin.x + 0.3f)
                {
                    transform.position = new Vector3(transform.position.x - moveHorizontally, transform.position.y, transform.position.z);
                }
                else if (curHorizontalPos < ray[ball].origin.x - 0.3f)
                {
                    transform.position = new Vector3(transform.position.x + moveHorizontally, transform.position.y, transform.position.z);
                }
                if (transform.position.x >= ray[ball].origin.x - 0.1f && transform.position.x <= ray[ball].origin.x + 0.1f)
                {
                    transform.position = new Vector3(ray[ball].origin.x, transform.position.y, transform.position.z);
                    curHorizontalPos = transform.position.x;
                }
            }
            else if (hittedObj[ball + 1].transform.CompareTag("Ramp"))
            {
                if (curHorizontalPos > ray[ball].origin.x + 1.8f)
                {
                    transform.position = new Vector3(transform.position.x - moveHorizontally, transform.position.y, transform.position.z);
                }
                else if (curHorizontalPos < ray[ball].origin.x + 1.2f)
                {
                    transform.position = new Vector3(transform.position.x + moveHorizontally, transform.position.y, transform.position.z);
                }
                if (transform.position.x >= ray[ball].origin.x - 1.4f && transform.position.x <= ray[ball].origin.x + 1.6f)
                {
                    transform.position = new Vector3(ray[ball].origin.x + 1.5f, transform.position.y, transform.position.z);
                    curHorizontalPos = transform.position.x;
                }
            }
            else if (hittedObj[ball - 1].transform.CompareTag("Ramp"))
            {
                if (curHorizontalPos > ray[ball].origin.x - 1.2f)
                {
                    transform.position = new Vector3(transform.position.x - moveHorizontally, transform.position.y, transform.position.z);
                }
                else if (curHorizontalPos < ray[ball].origin.x - 1.8f)
                {
                    transform.position = new Vector3(transform.position.x + moveHorizontally, transform.position.y, transform.position.z);
                }
                if (transform.position.x >= ray[ball].origin.x - 1.6f && transform.position.x <= ray[ball].origin.x - 1.4f)
                {
                    transform.position = new Vector3(ray[ball].origin.x - 1.5f, transform.position.y, transform.position.z);
                    curHorizontalPos = transform.position.x;
                }
            }
        }
    }

}