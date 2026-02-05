using UnityEngine;

public class TriggerRotate : MonoBehaviour
{
    [SerializeField] private RotateTrap trapScript;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            trapScript.TrapTrigger();
        }
    }
}
