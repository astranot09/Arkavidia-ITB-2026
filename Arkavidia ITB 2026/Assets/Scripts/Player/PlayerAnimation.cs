using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator animator;
    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    private bool isLookingRight = true;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        rb = GameObject.Find("Player").GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (rb.linearVelocityX > 0.5f && !isLookingRight)
        {
            spriteRenderer.flipX = false;
            isLookingRight = true;
        }
        else if (rb.linearVelocityX < -0.5f && isLookingRight)
        {
            spriteRenderer.flipX = true;
            isLookingRight = false;
        }
            animator.SetFloat("VelocityX", Mathf.Abs(rb.linearVelocityX));
            animator.SetFloat("VelocityY", Mathf.Abs(rb.linearVelocityY));
    }
}
