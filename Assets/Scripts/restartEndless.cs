using UnityEngine;
using UnityEngine.SceneManagement;

public class restartEndless : MonoBehaviour {
    
    public void RestartEndless ()
    {
        FindObjectOfType<AudioManager>().Play("EndlessModeMusic");
        SceneManager.LoadScene("Endless");
    }

    public void LoadMenu ()
    {
        SceneManager.LoadScene(0);
    }

    public void Quit ()
    {
        Application.Quit();
    }

}
