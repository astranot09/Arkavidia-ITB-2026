using UnityEngine;

public class TriggerScale : MonoBehaviour
{
    [SerializeField] private ScaleTrap trapScript;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            trapScript.TrapTrigger();
        }
    }
}
