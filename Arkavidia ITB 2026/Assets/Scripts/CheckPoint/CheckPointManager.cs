using UnityEngine;

public class CheckPointManager : MonoBehaviour
{
    public static CheckPointManager instance;
    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        Debug.Log("Ga ilang kan meki");
    }

    [SerializeField] private Transform lastCheckpoint;
    [SerializeField] private string checkpointName;
    [SerializeField] private string colliderName;
    [SerializeField] private Collider2D saveCollider;

    public void setCheckPoint(Transform checkpointLocation, string nameSavePoint, string colliderName)
    {
        Debug.Log("name");
        lastCheckpoint = checkpointLocation;
        checkpointName = nameSavePoint;
        this.colliderName = colliderName;
    }

    public Transform GetLastCheckPoint()
    {
        Debug.Log("Hi meki");
        //if(checkpointName!=null)
        //    lastCheckpoint = GameObject.Find(checkpointName).transform;
        return lastCheckpoint;
    }
    public Transform SpawnAtCheckPoint()
    {
        Debug.Log("Hi meki");
        if (checkpointName != null)
            lastCheckpoint = GameObject.Find(checkpointName).transform;
        return lastCheckpoint;
    }
    public Collider2D SpawnAtCamera()
    {
        Debug.Log("Hi meki");
        if (colliderName != null)
            saveCollider = GameObject.Find(colliderName).GetComponent<Collider2D>();
        return saveCollider;
    }

}
