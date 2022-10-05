using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    private Rigidbody2D rb;
   [SerializeField] private bool moveLeft;
    [SerializeField] private bool moveRight;
    private float horizontalMove;
    public float speed = 10;
    public float jumpSpeed = 20;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        moveLeft = false;
        moveRight = false;
    }

    public void PointerDownLeft()
    {
        moveLeft = true;
    }

    public void PointerUpLeft()
    {
        moveLeft = false;
    }

    public void PointerDownRight()
    {
        moveRight = true;
    }

    public void PointerUpRight()
    {
        moveRight = false;
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
    }

    private void MovePlayer()
    {
        if (moveLeft)
        {
            horizontalMove = -speed;
        }
        else if (moveRight)
        {
            horizontalMove = speed;
        }
        else
        {
            horizontalMove = 0;
        }
    }
    public void jumpButton()
    {
        if(rb.velocity.y ==0)
        {
            rb.velocity = Vector2.up * jumpSpeed;
        }
    }
    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontalMove, rb.velocity.y);
    }
}