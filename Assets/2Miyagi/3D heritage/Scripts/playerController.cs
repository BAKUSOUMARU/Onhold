using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 moveDirection = Vector3.zero;

    public float _mainSpeed = 3.0f;
    public float _mainJampSpeed = 8.0f;
    public float _gravity = 20.0f;
    void Start(){
        controller = GetComponent<CharacterController>();
    }
    void Update()
    {
        if (controller.isGrounded)
        {
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection = moveDirection * _mainSpeed;
            if (Input.GetButton("Jump"))
            {
                moveDirection.y = _mainJampSpeed;
            }
        }
        moveDirection.y = moveDirection.y - (_gravity * Time.deltaTime);
        controller.Move(moveDirection * Time.deltaTime);
    }
}
