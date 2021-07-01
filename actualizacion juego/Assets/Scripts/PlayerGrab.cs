using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGrab : MonoBehaviour
{
    public GameObject ball;
    public GameObject myHand;
    bool inHands=false;
    public float handPower;

    Collider ballCol;
    Rigidbody ballRb;
    Camera cam;
    // Start is called before the first frame update
    void Start()
    {

        ballCol = ball.GetComponent<SphereCollider>();
        ballRb = ball.GetComponent<Rigidbody>();
        cam = GetComponentInChildren<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Debug.Log("grabAction");
            if (!inHands && myHand.GetComponent<Grab>().canGrab)
            {
            Debug.Log("agarrar");
                ballCol.isTrigger = true;
                ball.transform.SetParent(myHand.transform);
                ball.transform.localPosition = new Vector3(0f, -.5f, 0f);
                ballRb.velocity = Vector3.zero;
                ballRb.useGravity = false;
                inHands = true;
            }else if (inHands)
            {
            Debug.Log("soltar");
                ballCol.isTrigger = false;
                ballRb.useGravity = true;
                this.GetComponent<PlayerGrab>().enabled = false;
                ball.transform.SetParent(null);
                ballRb.velocity = cam.transform.rotation * Vector3.forward * handPower;
                inHands = false;
            }
        }
    }
}
