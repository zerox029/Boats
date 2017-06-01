using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumping : MonoBehaviour {

    public float thrust;

    [Space(10)]
    public Rigidbody rb;
    public new Collider collider;

    private int jumpAmount;

    private void Update () {
        if (IsGrounded())
        {
            jumpAmount = 0;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
	}

    bool IsGrounded()
    {
        return Physics.Raycast(transform.position, -Vector3.up, 0.1f);
    }

    private void Jump()
    {
        if (jumpAmount < 2)
        {
            if(jumpAmount == 0)
            {
                rb.AddForce(transform.up * thrust);
                jumpAmount++;
            }
            else
            {
                rb.AddForce(transform.up * (thrust/2));
                jumpAmount++;
            }

        }
    }
}
