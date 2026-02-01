using UnityEngine;

public class CheckPointScript : MonoBehaviour
{
    [SerializeField] private Transform saveLocation;
    [SerializeField] private string nameCheckPoint;
    [SerializeField] private Collider2D camCollider;
    [SerializeField] private string nameCollider;

    private void Start()
    {
        nameCheckPoint = gameObject.name;
        nameCollider = camCollider.name;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player")) return;
        Transform x = CheckPointManager.instance.GetLastCheckPoint();
        if (x == saveLocation)
            return;
        else
            CheckPointManager.instance.setCheckPoint(saveLocation, nameCheckPoint, nameCollider);
    }

}
