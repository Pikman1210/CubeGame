using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCollision : MonoBehaviour {

    public GameObject player;

    public PlayerMovement movement;
    public Rigidbody rb;

    public float yRespawnHeight = 1f;

    private string CurrentScene;
    private float zPosition;
    private float xRotation;
    private float yRotation;
    private float zRotation;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        xRotation = transform.rotation.x;
        yRotation = transform.rotation.y;
        zRotation = transform.rotation.z;
    }

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

        if (collisionInfo.collider.tag == "HeightLimit")
        {
            zPosition = transform.position.z;
            zPosition = zPosition - 15;
            transform.position = new Vector3(0f, yRespawnHeight, zPosition);
            transform.rotation = new Quaternion(xRotation, yRotation, zRotation, 0);
            rb.velocity = new Vector3(0, 0, 0);
        }
    }

}
