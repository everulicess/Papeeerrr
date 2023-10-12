using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] CharacterController controller;
    [SerializeField] GameManager gameManager;

    [SerializeField] float speed = 12f;
    [SerializeField] float gravity = 10f;
    [SerializeField] float jumpHeight = 1f;

    [SerializeField] Transform groundCheck;
    [SerializeField] float groundDistance = 0.4f;
    [SerializeField] LayerMask groundMask;

    Vector3 velocity;
    bool isGrounded;


    private void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }


        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            Debug.Log("is Jumping");
            velocity.y = Mathf.Sqrt(jumpHeight * 2f * gravity);
        }
        velocity.y -= gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);


    }
}
