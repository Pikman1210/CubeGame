using UnityEngine;

public class PlayerCollision : MonoBehaviour {

    public GameManager gameManager;
    public PlayerMovement movement;
    void OnCollisionEnter(Collision collisionInfo) 
    {
        if (collisionInfo.collider.tag == "Obstacle")
        {
            movement.enabled = false;
            FindObjectOfType<GameManager>().EndGame();
        }

        if (collisionInfo.collider.tag == "SecretTrigger")
        {
            gameManager.SecretLevelTriggered();
        }
    }

}
