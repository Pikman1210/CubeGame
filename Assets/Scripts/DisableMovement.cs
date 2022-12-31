using UnityEngine;

public class DisableMovement : MonoBehaviour{

    public PlayerMovement movement;

    void OnTriggerEnter()
    {
        Invoke("DisablePlayerMovement", 1f);
    }

    private void DisablePlayerMovement ()
    {
        movement.enabled = false;
    }

}
