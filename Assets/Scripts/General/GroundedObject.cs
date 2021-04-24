using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundedObject : MonoBehaviour
{
    public Transform checkPoint;
    [HideInInspector] public bool isGrounded;

    virtual public void FixedUpdate()
    {
        Collider2D[] collisions = Physics2D.OverlapCircleAll(checkPoint.position, 0.2f);
        foreach (Collider2D c in collisions)
        {
            if (c.transform.root != transform)
            {
                isGrounded = true;
            } else
            {
                isGrounded = false;
            }
        }
    }
}
