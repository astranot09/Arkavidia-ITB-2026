using UnityEngine;

public class CheckPointManager : MonoBehaviour
{
    public static CheckPointManager instance;
    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
        DontDestroyOnLoad(gameObject);
    }

    [SerializeField] private Transform lastCheckpoint;

    public void setCheckPoint(Transform checkpointLocation)
    {
        lastCheckpoint = checkpointLocation;
    }

    public Transform GetLastCheckPoint()
    {
        return lastCheckpoint;
    }

}
