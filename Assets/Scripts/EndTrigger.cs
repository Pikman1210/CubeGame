using UnityEngine;
using UnityEngine.SceneManagement;

public class EndTrigger : MonoBehaviour
{

    public GameManager gameManager;
    Scene scene;

    void OnTriggerEnter ()
    {
        FindObjectOfType<AudioManager>().Play("LevelComplete");
        scene = SceneManager.GetActiveScene();
        gameManager.CompleteLevel();
    }

}
