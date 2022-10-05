using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playermovementjoy : MonoBehaviour
{
    public MoveMentJoystick movementJoystick;
    public float playerSpeed;
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        if (movementJoystick.joystickVec.y != 0) 
        {
            rb.velocity = new Vector2(movementJoystick.joystickVec.x * playerSpeed, movementJoystick.joystickVec.y * playerSpeed);
        }

        else
        {
            rb.velocity = Vector2.zero;
        }
    }
}
