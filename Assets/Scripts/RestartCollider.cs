using UnityEngine;

public class RestartCollider : MonoBehaviour {

    bool dead = false;

    void OnTriggerEnter()
    {
        if (dead == false)
        {
            dead = true;
            FindObjectOfType<AudioManager>().Play("FallingGameOver");
            FindObjectOfType<GameManager>().EndGame();
        }
    }

}