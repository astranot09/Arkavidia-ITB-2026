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

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currSpeed = speed;
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
    }
}
