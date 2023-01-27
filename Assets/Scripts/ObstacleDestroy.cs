using UnityEngine;

public class ObstacleDestroy : MonoBehaviour {

    public Rigidbody rb;

    public float deathHeight = -5f;

    private void FixedUpdate()
    {
        if (rb.position.y < deathHeight)
        {
            Destroy(gameObject);
        }
    }
}
