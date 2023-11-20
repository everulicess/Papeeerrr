using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] CharacterController controller;
    [SerializeField] GameManager gameManager;

    [SerializeField] float speed = 3f;
    [SerializeField] float gravity = 10f;
    [SerializeField] float jumpHeight = 1f;

    [SerializeField] Transform groundCheck;
    [SerializeField] float groundDistance = 0.4f;
    [SerializeField] LayerMask groundMask;

    Vector3 velocity;
    bool isGrounded;


    GameManager gM;
    bool wPressed, aPressed, sPressed, dPressed = false;
    private void Awake()
    {
        gM = GameObject.FindObjectOfType<GameManager>();
    }
    
    private void Update()
    {
        if (gM.isPlayerControl)
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                speed = 4.5f;
                gM.isRunning = true;
            }
            else
            {
                speed = 3f;
                gM.isRunning = false;
            }
            isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

            if (isGrounded && velocity.y < 0)
            {
                velocity.y = -2f;
            }


            float x = Input.GetAxis("Horizontal");
            float z = Input.GetAxis("Vertical");

            Vector3 move = transform.right * x + transform.forward * z;

            controller.Move(move * speed * Time.deltaTime);

            
            if (Input.GetKeyDown(KeyCode.W))
            {
                wPressed = true;
            }
            if (Input.GetKeyDown(KeyCode.A))
            {
                aPressed = true;
            }
            if (Input.GetKeyDown(KeyCode.S))
            {
                sPressed = true;
            }
            if (Input.GetKeyDown(KeyCode.D))
            {
                dPressed = true;
            }
            if (aPressed&&sPressed&&dPressed&&wPressed)
            {
                gM.movementControlsDone = true;
            }

            
            if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
            {
                Debug.Log("is Jumping");
                velocity.y = Mathf.Sqrt(jumpHeight * 2f * gravity);
            }
            velocity.y -= gravity * Time.deltaTime;

            controller.Move(velocity * Time.deltaTime);
        }
        else
        {
            gM.spacePressed = Input.GetKeyDown(KeyCode.Space);
        }
        


    }
}
