using UnityEngine;

public class SecretLevelEndTrigger : MonoBehaviour {

    public GameManager gameManager;

    void OnTriggerEnter()
    {
        gameManager.SecretCompleteLevel();
    }
}
