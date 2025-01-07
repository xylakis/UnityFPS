using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// taken from https://www.youtube.com/watch?v=_QajrabyTJc

public class PlayerMovement : MonoBehaviour
{
    //#1 
    public CharacterController controller;
    public float speed = 2f;
    
    public float gravity = -9.81f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    
    //we dont want this to register just because this sphere collides with the player
    public LayerMask groundMask;

    Vector3 velocity;
    bool isGrounded;

    public float jumpHeight = 1.5f;

    void Update()
    {
        // Player movement on the X and Z axis 
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        // Compute movement 
        Vector3 move = transform.right * x + transform.forward * z;

        // Apply movement
        controller.Move(move * speed * Time.deltaTime);

        // https://docs.unity3d.com/ScriptReference/Physics.CheckSphere.html
        // Returns true if there are any colliders overlapping the sphere defined by position and radius in world coordinates.
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y<0)
        {
            velocity.y = -2f;
        }


        // Check if the Jump button was pressed and
        // if the player touches elements that are part of the Ground (in LayerMask groundMask) 
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            //jumping
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        // faling down
        // Player velocity changes each frame based on the force of gravity
        // Formula of the force of gravity --> dy = 1/2*g * t^2
        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }
}
