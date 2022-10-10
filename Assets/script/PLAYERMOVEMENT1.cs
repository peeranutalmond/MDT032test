using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PLAYERMOVEMENT : MonoBehaviour
{
    Rigidbody2D rb;
    public float speed;
    public Joystick mj;
    public float jumpspeed;
    public CharacterController2D controller;
    bool jump = false;
    float horizontalmove;
    float x;
    bool crouch = false;
    [Range(1, 10)]
    public float jumpvelocity;
    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        verticalmove();
    }

//private code
    private void FixedUpdate()
    {

        controller.Move(horizontalmove * Time.fixedDeltaTime, crouch, jump);
        jump = false;
    }
    private void verticalmove()
    {
        horizontalmove = x = mj.Horizontal * speed;
        rb.velocity = new Vector2(x * speed, rb.velocity.y);
        float verticalmove = mj.Vertical * jumpspeed;
        if (verticalmove >= 7f)
        {
            jump = true;
        }
        if (verticalmove > -1f)
        {
            crouch = false;
        }
        else if (verticalmove < -4.5f)
        {
            crouch = true;
        }
        if (verticalmove >= 0f)
        {
            crouch = false;
        }
    }
}