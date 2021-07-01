using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grab : MonoBehaviour
{
    public bool canGrab=false;

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ball"))
        {
            Debug.Log("i can grab");
            canGrab = true;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        Debug.Log("i can not grab");
        canGrab = false;
    }
}
