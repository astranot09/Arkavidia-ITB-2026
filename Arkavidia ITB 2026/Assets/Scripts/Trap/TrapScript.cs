using UnityEngine;

public class TrapScript : MonoBehaviour
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

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            moveToTarget = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            IDamageable damageable = collision.gameObject.GetComponent<IDamageable>();

            if (damageable != null)
            {
                damageable.getDamage(1f);
            }
        }
    }
}