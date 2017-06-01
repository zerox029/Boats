using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

    public GameObject boat;
    public Text scoreTxt;

    [Space(15)]
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

        if(hit.collider != null && hit.transform.tag == "Obstacle")
        {
            UpdateScore();
            return true;
        }
        else
        {
            return false;
        }
    }

    private void UpdateScore()
    {
        score++;
        scoreTxt.text = score.ToString();
    }
}
