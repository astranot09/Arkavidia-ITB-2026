using System.Collections;
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

    [Header("Bulak Balik")]
    public bool BulakBalik = false;
    public Vector2 titikAwal;
    public Vector2 titikAhir;
    public float delay;
    public float startDelay;
    [SerializeField] private TrapScript otherTrap;

    [SerializeField] private bool giveDamage = true;


    void Start()
    {
        titikAwal = this.gameObject.transform.position;
        if (BulakBalik)
        {
            StartCoroutine( BolakBalikFunction());
        }
    }

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

    IEnumerator BolakBalikFunction()
    {

        yield return new WaitForSeconds(startDelay);
        while (true)
        {
            yield return MoveTo(titikAhir);
            yield return new WaitForSeconds(delay);
            yield return MoveTo(titikAwal);
            yield return new WaitForSeconds(delay);
        }
    }

    IEnumerator MoveTo(Vector2 target)
    {
        while (Vector2.Distance(transform.position, target) > 0.01f)
        {
            transform.position = Vector2.MoveTowards(
                transform.position,
                target,
                speed * Time.deltaTime
            );
            yield return null; // jalan tiap frame
        }
    }

}