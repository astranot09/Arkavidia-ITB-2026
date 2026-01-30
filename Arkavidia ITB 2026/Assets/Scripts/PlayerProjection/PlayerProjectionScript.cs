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
    [SerializeField] private Vector2 dir = Vector2.right;

    [SerializeField] private float jumpForce;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currSpeed = speed;
    }

    // Update is called once per frame
    void Update()
    {
        rb.linearVelocity = new Vector2(dir.x * currSpeed, rb.linearVelocityY);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("ProjectionReverse"))
        {
            dir *= -1;
        }
        if (collision.CompareTag("ProjectionJump"))
        {
            rb.linearVelocity = new Vector2(rb.linearVelocityX, jumpForce);
        }
        if (collision.CompareTag("ProjectionStop"))
        {
            currSpeed = 0;
        }
        if (collision.CompareTag("ProjectionMove"))
        {
            currSpeed = speed;
        }
    }
}
