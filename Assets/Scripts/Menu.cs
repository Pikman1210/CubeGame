using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {
    
    public void StartGame ()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); // Goes to next scene in order
    }

    public void Quit()
    {
        Debug.Log("Quit");
        Application.Quit(); // Quits the game (duh)
    }

}
