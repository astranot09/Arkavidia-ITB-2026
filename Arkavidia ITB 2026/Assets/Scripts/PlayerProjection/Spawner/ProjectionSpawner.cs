using UnityEngine;

public class ProjectionSpawner : MonoBehaviour
{
    [SerializeField] private GameObject playerProjectionPrefab;
    [SerializeField] private Transform playerSpawn;

    private void Start()
    {
        Spawn();
    }
    public void Spawn()
    {
        GameObject projection = Instantiate(playerProjectionPrefab, playerSpawn);
        projection.GetComponent<PlayerProjectionScript>().projectionSpawn = this;
    }

}
