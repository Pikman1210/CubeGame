using UnityEngine;

public class GroundSpawner : MonoBehaviour {

    public GameObject groundTile;
    Vector3 nextSpawnPoint;

    void Start()
    {
        for (int i = 0; i < 5; i++)
        {
            SpawnTile();
        }
    }

    public void SpawnTile ()
    {
        GameObject temp = Instantiate(groundTile, nextSpawnPoint, Quaternion.identity);
        nextSpawnPoint = temp.transform.GetChild(1).transform.position;
    }

}
