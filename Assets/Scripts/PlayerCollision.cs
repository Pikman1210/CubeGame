using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCollision : MonoBehaviour {

    public PlayerMovement movement;
    private string CurrentScene;

    void OnCollisionEnter(Collision collisionInfo) 
    {
        if (collisionInfo.collider.tag == "Obstacle")
        {
            CurrentScene = SceneManager.GetActiveScene().name;

            if (CurrentScene == "Endless")
            {
                FindObjectOfType<AudioManager>().Play("ObstacleGameOver");
                movement.enabled = false;
                FindObjectOfType<GameManager>().EndEndless();
                return;
            }

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
