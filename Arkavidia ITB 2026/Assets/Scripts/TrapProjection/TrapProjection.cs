using UnityEngine;

public class TrapProjection : MonoBehaviour
{
    [SerializeField] private Transform location;
    [SerializeField] private Vector2 normalLocation;
    [SerializeField] private float speed = 5f;

    [SerializeField] private bool moveToTarget = false;
    [SerializeField] private bool backToOriginal = false;

    private void Start()
    {
        normalLocation = this.gameObject.transform.position;
    }

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
        if (backToOriginal)
        {
            transform.position = Vector2.MoveTowards(
                transform.position,
                normalLocation,
                speed * Time.deltaTime
            );
        }
    }

    public void TrapTrigger()
    {
        moveToTarget = true;
        backToOriginal = false;
    }

    public void BackToNormal()
    {
        moveToTarget = false;
        backToOriginal = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("ProjectionBackNormal"))
        {
            BackToNormal();
        }
    }


    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.gameObject.CompareTag("PlayerProjection"))
    //    {
    //        moveToTarget=false;
    //        backToOriginal = true;
    //    }
    //}
}
