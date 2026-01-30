using UnityEngine;

public class CheckPointScript : MonoBehaviour
{
    [SerializeField] private Transform saveLocation;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player")) return;
        Transform x = CheckPointManager.instance.GetLastCheckPoint();
        if (x == saveLocation)
            return;
        else
            CheckPointManager.instance.setCheckPoint(saveLocation);
    }

}
