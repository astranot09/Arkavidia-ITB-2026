using UnityEngine;

public class TrapScript : MonoBehaviour
{
    [SerializeField] private Transform location;
    [SerializeField] private float speed = 5f;

    private bool moveToTarget = false;

    public bool otherTrigger = false;


    [Header("One Used")]
    public bool oneTime = false;
    public bool alreadyTrigger = false;


    [SerializeField] private TrapScript otherTrap;

    [SerializeField] private bool giveDamage = true;
    
    void Update()
    {
        if (moveToTarget)
        {
            if(oneTime && !alreadyTrigger)
            {
                alreadyTrigger = true;
                TrapDo();
            }
            else if (!oneTime)
                TrapDo();

        }
    }

    public void TrapTrigger()
    {
        if (otherTrap != null)
        {
            if (!otherTrap.otherTrigger)
            {
                return;
            }
        }
        moveToTarget = true;
        otherTrigger = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (!giveDamage) return;

            IDamageable damageable = collision.gameObject.GetComponent<IDamageable>();

            if (damageable != null)
            {
                damageable.getDamage(1f);
            }
        }
    }

    protected virtual void TrapDo()
    {
        transform.position = Vector2.MoveTowards(
        transform.position,
        location.position,
        speed * Time.deltaTime
        );
    }

}