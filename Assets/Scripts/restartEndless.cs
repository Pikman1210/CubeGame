using UnityEngine;
using UnityEngine.SceneManagement;

public class restartEndless : MonoBehaviour {
    
    public void RestartEndless ()
    {
        SceneManager.LoadScene("Endless");
    }

    public void LoadMenu ()
    {
        SceneManager.LoadScene(0);
    }

}
