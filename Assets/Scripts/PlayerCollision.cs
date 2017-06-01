using UnityEngine;

public class PlayerCollision : MonoBehaviour {

    private void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.tag == "Player")
        {
            Debug.Log("Game Over");
            Time.timeScale = 0;
        }
    }
}
