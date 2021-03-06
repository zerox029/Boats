﻿using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody rb;
    public new Collider collider;

    [Header("Foward Movement")]
    public float speed;

    [Header("Jumping")]
    public float thrust;
    private int jumpAmount;

    private void Update()
    {
        //Jumping
        if (IsGrounded())
        {
            jumpAmount = 0;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }

        MoveForward();
    }

    /// <summary>
    /// Moves the player on the x axis automatically, called from Update
    /// </summary>
    private void MoveForward()
    {
        rb.MovePosition(transform.position +- transform.right * speed * Time.deltaTime);
    }

    /// <summary>
    /// Returns a bool to check whether ot not the player is touching the ground
    /// </summary>
    public bool IsGrounded()
    {
        Ray ray = new Ray(transform.position, -Vector3.up);
        RaycastHit hit;

        Physics.Raycast(ray, out hit, 0.1f);

        if(hit.collider != null && hit.collider.tag == "Ground")
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    /// <summary>
    /// Making the player jump. It also handle double jumping
    /// </summary>
    private void Jump()
    {
        if (jumpAmount < 2)
        {
            if (jumpAmount == 0)
            {
                rb.velocity = new Vector3(0f, 0f, 0f);
                rb.AddForce(transform.up * thrust);
                jumpAmount++;
            }
            else
            {
                rb.velocity = new Vector3(0f, 0f, 0f);
                rb.AddForce(transform.up * thrust);
                jumpAmount++;
            }

        }
    }
}
