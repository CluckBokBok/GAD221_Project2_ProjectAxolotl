using UnityEngine;

public class NPCAnimatorController : MonoBehaviour
{
    public Animator animator;
    public float baseAnimSpeed = 1f;
    public float movementThreshold = 0.05f;

    private Vector3 lastPosition;
    private Vector3 currentVelocity;

    void Start()
    {
        lastPosition = transform.position;
    }

    void Update()
    {
        Vector3 delta = transform.position - lastPosition;
        currentVelocity = delta / Time.deltaTime;

        float speed = currentVelocity.magnitude;
        animator.SetFloat("Speed", speed);

        // Flip NPC sprite based on horizontal direction
        if (Mathf.Abs(currentVelocity.x) > movementThreshold)
        {
            Vector3 originalScale = transform.localScale;
            transform.localScale = new Vector3(-Mathf.Sign(currentVelocity.x) * Mathf.Abs(originalScale.x), originalScale.y, originalScale.z);


        }

        // Control animation playback speed
        animator.speed = (speed > movementThreshold) ? baseAnimSpeed : 0f;

        lastPosition = transform.position;
    }
}
