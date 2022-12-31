using UnityEngine;

public class EnableMovement : MonoBehaviour {

    public PlayerMovement movement;
    public float EnableDelay = 2f;

    void OnTriggerEnter()
    {
        Invoke("EnablePlayerMovement", EnableDelay);
    }

    private void EnablePlayerMovement()
    {
        movement.enabled = true;
    }
}
