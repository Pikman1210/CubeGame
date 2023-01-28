using UnityEngine;

public class GroundTile : MonoBehaviour {

    public GameObject[] obstacles;

    GroundSpawner groundSpawner;

    private void Start()
    {
        groundSpawner = FindObjectOfType<GroundSpawner>();
        SpawnObstacle();
    }

    private void Update()
    {
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            groundSpawner.SpawnTile();
            Destroy(gameObject, 3);
        }
        
    }

    public void SpawnObstacle ()
    {
        // Choose random point for obstacle then spawn there
        int obstacleSpawnIndex = Random.Range(2, 3);
        Transform spawnPoint = transform.GetChild(obstacleSpawnIndex).transform;

        Instantiate(obstacles[Random.Range(0, obstacles.Length)], spawnPoint.position, Quaternion.identity, transform);
    }

}
