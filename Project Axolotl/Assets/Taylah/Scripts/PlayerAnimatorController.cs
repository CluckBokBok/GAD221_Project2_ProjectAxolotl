using UnityEngine;

public class PlayerAnimatorController : MonoBehaviour
{
    public Animator animator;
    private FloatController floatController;
    private Rigidbody2D rb;

    public float baseAnimSpeed = 1f;
    public float dashAnimSpeed = 1.75f;

    void Start()
    {
        floatController = GetComponent<FloatController>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Vector2 velocity = rb.velocity;
        float speed = velocity.magnitude;

        // Flip sprite based on horizontal movement
        if (velocity.x != 0)
        {
            transform.localScale = new Vector3(-Mathf.Sign(velocity.x), 1, 1);
        }

        // Set animation parameters
        animator.SetFloat("Speed", speed);

        bool isDashing = Input.GetKey(KeyCode.LeftShift);
        animator.SetBool("IsDashing", isDashing);

        // Set animation playback speed
        if (speed < 0.1f)
        {
            animator.speed = 0f; // Stop animation when idle
        }
        else
        {
            animator.speed = isDashing ? dashAnimSpeed : baseAnimSpeed;
        }
    }
}



