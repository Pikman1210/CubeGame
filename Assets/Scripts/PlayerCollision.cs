using UnityEngine;

public class PlayerCollision : MonoBehaviour {

    public PlayerMovement movement;
    void OnCollisionEnter(Collision collisionInfo) 
    {
        if (collisionInfo.collider.tag == "Obstacle")
        {
            FindObjectOfType<AudioManager>().Play("ObstacleGameOver");
            movement.enabled = false;
            FindObjectOfType<GameManager>().EndGame();
        }

        if (collisionInfo.collider.tag == "SecretTrigger")
        {
            FindObjectOfType<AudioManager>().Play("SecretTriggered");
            FindObjectOfType<GameManager>().SecretLevelTriggered();
        }
    }

}
