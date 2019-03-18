using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PostRampMovement : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
            other.transform.position = new Vector3(other.transform.position.x, 1, other.transform.position.z);
    }


}
