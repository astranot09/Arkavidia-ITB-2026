using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    [SerializeField] private float distance;
    [SerializeField] private float radius;
    [SerializeField] private LayerMask interactLayer;
    private MovementPlayer movementPlayer;
    private Vector2 dir;
    private Vector2 lastDir;
    private RaycastHit2D hit;
    private IInteractable interactable;
    private IInteractable lastInteractable;

    private void Start()
    {
        movementPlayer = GetComponent<MovementPlayer>();
    }
    private void FixedUpdate()
    {
        dir = new Vector2(movementPlayer.direction.x, 0f);
        if (dir != Vector2.zero) {
            lastDir = dir.normalized;
        }
        hit = Physics2D.CircleCast(transform.position, radius, lastDir, distance, interactLayer);

        if (hit.collider != null)
        {
            interactable = hit.collider.GetComponent<IInteractable>();
            if(interactable != lastInteractable)
            {
                if(lastInteractable != null)
                {
                    lastInteractable.OffFocus();
                }
                lastInteractable = interactable;
            }
            interactable.OnFocus();
        }
        else
        {
            if (lastInteractable != null)
            {
                lastInteractable.OffFocus();
            }
            lastInteractable = interactable;
        }
    }

    private void OnDrawGizmos()
    {
        if (!Application.isPlaying) return;

        Gizmos.color = Color.green;

        Vector3 start = transform.position;
        Vector3 dir3 = (Vector3)lastDir.normalized;

        // Draw starting circle
        Gizmos.DrawWireSphere(start, radius);

        // Draw ending circle
        Vector3 end = start + dir3 * distance;
        Gizmos.DrawWireSphere(end, radius);

        // Draw line between them
        Gizmos.DrawLine(start, end);
    }
}
