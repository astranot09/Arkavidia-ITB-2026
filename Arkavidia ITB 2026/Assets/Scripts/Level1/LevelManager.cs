using System.Collections;
using UnityEngine;
using Unity.Cinemachine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;

    [SerializeField] private Transform playerLocation;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
    }

    private void Start()
    {
        StartCoroutine(delay());
    }

    IEnumerator delay()
    {
        yield return null;
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        playerLocation = CheckPointManager.instance.SpawnAtCheckPoint();
        CinemachineConfiner2D camera = GameObject.FindFirstObjectByType<CinemachineConfiner2D>(); ;
        camera.BoundingShape2D = CheckPointManager.instance.SpawnAtCamera();
        player.transform.position = playerLocation.position;
    }
}
