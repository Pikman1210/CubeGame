using UnityEngine;
using UnityEngine.SceneManagement;

public class EndTrigger : MonoBehaviour
{

    public GameManager gameManager;
    Scene scene;

    void OnTriggerEnter ()
    {
        FindObjectOfType<AudioManager>().Play("LevelComplete");
        scene = SceneManager.GetActiveScene(); // Debug.Log(scene.buildIndex);
        if (scene.buildIndex > PlayerPrefs.GetInt("Level", 0))
        {
            PlayerPrefs.SetInt("Level", scene.buildIndex);
        }
        gameManager.CompleteLevel();
    }

}
