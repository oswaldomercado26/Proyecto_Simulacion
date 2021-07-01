using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonMovement : MonoBehaviour
{
    public CharacterController controller;

    public Transform cam;

    public float speed = 6f;

    public float turnSmoothTime = 0.1f;
    private float turnSmoothVelocity;
    // Update is called once per frame
    
    
    [Header("Gravity")]
    public float gravity = 10;
    public float currentGravity;
    public float contstantGravity = -0.6f;
    public float maxGravity = -15;

    private Vector3 gravityDirection =  Vector3.down;
    private Vector3 gravityMovement;

    #region - Gravity -
    private bool isGrounded(){
        return controller.isGrounded;
    }

    private void CalculateGravity(){
        if(isGrounded()){
            currentGravity = contstantGravity;
        } else{
            if(currentGravity > maxGravity){
                currentGravity -= gravity * Time.deltaTime;
            }
        }
        gravityMovement = gravityDirection * -currentGravity * Time.deltaTime;
    }
    #endregion

    void Update()
    {
        CalculateGravity();
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        if(direction.magnitude >= 0.1f){

            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime );

            transform.rotation = Quaternion.Euler( 0f, angle, 0f);
            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(moveDir.normalized * speed * Time.deltaTime + gravityMovement);
        }
    }
    private void FixedUpdate() {
        controller.Move(gravityMovement);
    }
}
