using Unity.Cinemachine;
using Unity.VisualScripting;
using UnityEngine;

public class MapTransation : MonoBehaviour
{
    [SerializeField] private Collider2D boundInto;
    CinemachineConfiner2D confiner;
    [SerializeField] private Transform teleportTo;

    private void Awake()
    {
        confiner = FindFirstObjectByType<CinemachineConfiner2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("p");
            confiner.BoundingShape2D = boundInto;
            collision.transform.position = teleportTo.position;
        }
    }
}
