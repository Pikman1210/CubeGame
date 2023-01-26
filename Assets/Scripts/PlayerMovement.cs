using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    // Reference to Rigidbody component called rb
    public Rigidbody rb;

    bool dead = false;
    public float forwardForce = 2000f;
    public float sidewaysForce = 500f;

    // Update is called once per frame
    void FixedUpdate() // Use FixedUpdate instead of Update when calculating physics idk why ¯\_(:)_/¯
    {
        // Time.deltaTime changes value depending on frame rate, so cube doesn't zoom for me, but snail for others
        rb.AddForce(0, 0, forwardForce * Time.deltaTime); // Adds forward force (x,y,z)

        if ( Input.GetKey("d") || Input.GetKey(KeyCode.RightArrow))
        {
            rb.AddForce(sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }

        if (Input.GetKey("a") || Input.GetKey(KeyCode.LeftArrow))
        {
            rb.AddForce(-sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }

        if (rb.position.y < -1f && dead == false)
        {
            dead = true;
            FindObjectOfType<AudioManager>().Play("FallingGameOver");
            FindObjectOfType<GameManager>().EndGame();
        }
    }
}
