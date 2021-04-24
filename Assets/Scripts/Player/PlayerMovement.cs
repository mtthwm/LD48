using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : GroundedObject
{
    public float speed = 5f;
    public float jumpAccelleration = 5f;

    Rigidbody2D rb2d;
    float inputX;
    bool jump;
    bool attack; 

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();    
    }

    void Update()
    {
        inputX = Input.GetAxis("Horizontal");
        jump = Input.GetButton("Jump") && isGrounded;
        attack = Input.GetButton("Attack");
    }

    private void FixedUpdate()
    {
        Debug.Log(isGrounded);
        Vector2 velocity = rb2d.velocity;
        velocity.x = inputX * speed;

        if (jump)
        {
            velocity.y += jumpAccelleration;
        }

        rb2d.velocity = velocity;
    }
}
