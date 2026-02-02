using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public enum PathDo
{
    run,
    jump,
    reverse,
    stop,
    none
}

public class PlayerProjectionScript : MonoBehaviour
{
    private Rigidbody2D rb;


    [SerializeField] private float speed;
    [SerializeField] private float currSpeed;
    private Vector2 dir = Vector2.right;

    [SerializeField] private float jumpForce;
    [SerializeField] private Vector2 location;

    public ProjectionSpawner projectionSpawn;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currSpeed = speed;
        location = this.gameObject.transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(dir.x * currSpeed, rb.linearVelocity.y);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("ProjectionReverse"))
        {
            dir = -dir;
            Debug.Log("Reverse, dir = " + dir.x);
            collision.enabled = false; // biar cuma sekali
        }
        if (collision.CompareTag("ProjectionJump"))
        {
            Debug.Log("Jump");
            rb.linearVelocity = new Vector2(rb.linearVelocityX, jumpForce);
        }
        if (collision.CompareTag("ProjectionStop"))
        {
            Debug.Log("Stop");
            currSpeed = 0;
        }
        if (collision.CompareTag("ProjectionMove"))
        {
            Debug.Log("Move");
            currSpeed = speed;
        }
        if (collision.CompareTag("ProjectionDelete"))
        {
            Debug.Log("Delete");
            this.gameObject.transform.position = location;
            //projectionSpawn.Spawn();
            //Destroy(gameObject);
        }
        if (collision.CompareTag("ProjectionDead"))
        {
            Debug.Log("Dead");

            collision.GetComponent<TrapProjection>().BackToNormal();
            this.gameObject.transform.position = location;
            rb.linearVelocity = new Vector2 (0,0);
            //play dead anim
            //projectionSpawn.Spawn();
            //Destroy(gameObject);
        }
    }
}
