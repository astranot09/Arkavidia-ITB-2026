using UnityEngine;

public class TrapProjectionTrigger : MonoBehaviour
{
    [SerializeField] private TrapProjection trapProjectionScript;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PlayerProjection"))
        {
            trapProjectionScript.TrapTrigger();
        }
    }
}
