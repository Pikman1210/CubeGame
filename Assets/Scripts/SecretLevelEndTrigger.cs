using UnityEngine;

public class SecretLevelEndTrigger : MonoBehaviour {

    public GameManager gameManager;

    void OnTriggerEnter()
    {
        FindObjectOfType<AudioManager>().Play("SecretLevelComplete");
        gameManager.SecretCompleteLevel();
    }
}
