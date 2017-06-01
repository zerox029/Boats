using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour {

    public GameObject boat;
    public PlayerMovement movement;

    [SerializeField]
    private int score;
    private bool isOverObstacle = false;

	// Update is called once per frame
	void Update () {
        if(!isOverObstacle)
        {
            isOverObstacle = SendRaycast();
        }

        if (movement.IsGrounded())
        {
            isOverObstacle = false;
        }

	}

    private bool SendRaycast()
    {
        Ray ray = new Ray(boat.transform.position, -Vector3.up);
        RaycastHit hit;

        Physics.Raycast(ray, out hit);
        Debug.DrawRay(boat.transform.position, -Vector3.up * 10, Color.red);

        if(hit.transform.tag == "Obstacle")
        {
            score++;
            return true;
        }
        else
        {
            return false;
        }
    }
}
