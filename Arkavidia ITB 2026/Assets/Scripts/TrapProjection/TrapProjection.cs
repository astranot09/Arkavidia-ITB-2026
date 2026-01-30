using UnityEngine;

public class TrapProjection : MonoBehaviour
{
    [SerializeField] private Transform location;
    [SerializeField] private float speed = 5f;

    private bool moveToTarget = false;

    void Update()
    {
        if (moveToTarget)
        {
            transform.position = Vector2.MoveTowards(
                transform.position,
                location.position,
                speed * Time.deltaTime
            );
        }
    }

    public void TrapTrigger()
    {
        moveToTarget = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("PlayerProjection"))
        {
            IDamageable damageable = collision.gameObject.GetComponent<IDamageable>();

            if (damageable != null)
            {
                damageable.getDamage(1f);
            }
        }
    }
}
