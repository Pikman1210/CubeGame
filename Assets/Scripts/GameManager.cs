using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    bool gameHasEnded = false;
    public float restartDelay = 1f;
    public GameObject completeLevelUI;
    public GameObject secretLevelUI;
    public PlayerMovement movement;

    public void CompleteLevel ()
    {
        completeLevelUI.SetActive(true);
    }

    public void SecretCompleteLevel ()
    {
        completeLevelUI.SetActive(true);
    }

    public void SecretLevelTriggered()
    {
        movement.enabled = false;
        secretLevelUI.SetActive(true);
    }

    public void EndGame ()
    {
        if (gameHasEnded == false)
        {
            gameHasEnded = true;
            Debug.Log("Game over loser lmfao");
            Invoke("Restart", restartDelay);
        }
    }

    void Restart ()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Loads current scene
    }

}
