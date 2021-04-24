using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Grasshopper : GroundedObject
{
    public float cooldown = 3f;
    public float probability = 0.4f;
    public float maxJumpVelocity = 6f;
    
    Rigidbody2D rb2d;
    float lastJump = 0f;
    int dir = 1;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();    
    }

    override public void FixedUpdate()
    {
        base.FixedUpdate();
        float rand = Random.value;
        if (rand < probability && Time.time > lastJump + cooldown && this.isGrounded)
        {
            Jump();
        }
    }

    public void Jump ()
    {
        Vector3 rotate = this.transform.rotation.eulerAngles;
        rotate.y = dir == 1 ? 0 : 180;
        this.transform.rotation = Quaternion.Euler(rotate);
        rb2d.velocity = rb2d.velocity + new Vector2(Random.Range(0, 0.5f) * dir, Random.Range(0.8f, 1f)).normalized * maxJumpVelocity;
        lastJump = Time.time;
        dir *= -1;
    }
}
