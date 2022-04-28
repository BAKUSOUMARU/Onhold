using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 moveDirection = Vector3.zero;

    public float mainSpeed = 3.0f;
    public float mainJampSpeed = 8.0f;
    public float gravity = 20.0f;
    void Start(){
        controller = GetComponent<CharacterController>();
    }
    void Update()
    {
        if (controller.isGrounded)
        {
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection = moveDirection * mainSpeed;
            if (Input.GetButton("Jump"))
            {
                moveDirection.y = mainJampSpeed;
            }
        }
        moveDirection.y = moveDirection.y - (gravity * Time.deltaTime);
        controller.Move(moveDirection * Time.deltaTime);
    }
}
