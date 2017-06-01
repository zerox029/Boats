using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour {

    public GameObject boat;

	// Update is called once per frame
	void Update () {
        SendRaycast();
	}

    private void SendRaycast()
    {
        Ray ray = new Ray(boat.transform.position, -Vector3.up);
        RaycastHit hit;

        Physics.Raycast(ray, out hit);
        Debug.DrawRay(boat.transform.position, -Vector3.up * 10, Color.red);

        if(hit.transform.tag == "Obstacle")
        {
            Debug.Log("+1 Point");
        }
    }
}
