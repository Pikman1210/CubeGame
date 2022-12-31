using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelComplete : MonoBehaviour {
    
    public void LoadNextLevel ()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void LoadSecretLevel ()
    {
        SceneManager.LoadScene("LevelSecret");
    }

    public void LoadCredits()
    {
        SceneManager.LoadScene("Credits");
    }

}
