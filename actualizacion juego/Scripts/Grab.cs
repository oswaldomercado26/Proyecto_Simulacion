using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grab : MonoBehaviour
{
    public bool canGrab=false;

    public void OnTriggerEnter(Collider other)
    {
        //determinar el esapacio en el cual el personaje puede tomar el objeto para defenderse
        if (other.gameObject.CompareTag("Ball"))
        {
            Debug.Log("i can grab");
            canGrab = true;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        //determinar el espacio donde no puede tomar el objeto
        Debug.Log("i can not grab");
        canGrab = false;
    }
}
