using UnityEngine;
using UnityEngine.InputSystem;

public class MovementPlayer : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float jumpPower;
    private GroundChecker GroundChecker;
    private Rigidbody2D rb;
    public Vector2 direction { get; private set; }

    private void Awake()
    {
        GroundChecker = GameObject.Find("GroundChecker").GetComponent<GroundChecker>();
        rb = GetComponent<Rigidbody2D>();
    }

    public void Movement(InputAction.CallbackContext ctx)
    {
        direction = ctx.ReadValue<Vector2>();
    }

    public void Jump(InputAction.CallbackContext ctx)
    {
        if (ctx.performed && GroundChecker.isGrounded)
        {
            rb.linearVelocityY = jumpPower;
        }
        else
        {
            return;
        }
    }

    private void FixedUpdate()
    {
        Debug.Log(rb.linearVelocityY);
        rb.linearVelocity = new Vector2(direction.normalized.x * speed, rb.linearVelocityY);
    }
}
