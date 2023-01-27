using UnityEngine;

public class GroundTile : MonoBehaviour {

    GroundSpawner groundSpawner;

    private void Start()
    {
        groundSpawner = FindObjectOfType<GroundSpawner>();
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            groundSpawner.SpawnTile();
            Destroy(gameObject, 3);
        }
        
    }

}
