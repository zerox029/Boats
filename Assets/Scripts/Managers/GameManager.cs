using UnityEngine;

public class GameManager : MonoBehaviour {

    public GameObject player;
    public GameObject props;

	// Use this for initialization
	void Start ()
    {
        Instantiate(player, props.transform);
	}
}
