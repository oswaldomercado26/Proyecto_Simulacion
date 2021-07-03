using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MauseLook : MonoBehaviour
{

    public float mouseSensitivity = 300F;
    public Transform playerBody;

    float xRotation =  0f;

    // Start is called before the first frame update
    void Start()
    {
        //bloquea el mouse para que solo se ponga dentro del juego 
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        //sigue la camara a la posicion con respecto al mouse 
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
        //rota la camara siguiendo al mouse
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation,-90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);
    }
}
