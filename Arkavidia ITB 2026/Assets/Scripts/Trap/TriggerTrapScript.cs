using Unity.VisualScripting;
using UnityEngine;

public class TriggerTrapScript : MonoBehaviour
{
    [SerializeField] private TrapScript trapScript;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            trapScript.TrapTrigger();
        }
    }
}
