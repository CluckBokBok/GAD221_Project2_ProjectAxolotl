using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    // NOTE - in Project Settings -> Input Manager -> Axes -> Vertical, change alt postive button to "space"

    private Rigidbody2D playerRigidBody2D;

    public float moveSpeed;
    public float jumpPower;
    [SerializeField] private bool isJumping;

    private float moveHorizontal;
    private float moveVertical;

    public bool canMove; // allows player movement if true

    void Start()
    {
        playerRigidBody2D = gameObject.GetComponent<Rigidbody2D>();

        moveSpeed = 1.1f;
        jumpPower = 20f;
        isJumping = false;
        canMove = true;
    }

    void Update()
    {
        moveHorizontal = Input.GetAxisRaw("Horizontal");
        moveVertical = Input.GetAxisRaw("Vertical");

    }

    private void FixedUpdate()
    {
        if (canMove)
        {
            if (moveHorizontal > 0.1f || moveHorizontal < -0.1f) // A and D
            {
                playerRigidBody2D.AddForce(new Vector2(moveHorizontal * moveSpeed, 0f), ForceMode2D.Impulse);

            }

            if (!isJumping && moveVertical > 0.1f) // Spacebar
            {
                Vector2 currentVelocity = playerRigidBody2D.velocity;
                playerRigidBody2D.velocity = new Vector2(currentVelocity.x, 0f);

                playerRigidBody2D.AddForce(new Vector2(0f, moveVertical * jumpPower), ForceMode2D.Impulse);
            }
        }


    }

    private void OnTriggerEnter2D(Collider2D collision) // not jumping
    {
        if (collision.gameObject.tag == "Platform")
        {
            isJumping = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collision) // is jumping
    {
        if (collision.gameObject.tag == "Platform")
        {
            isJumping = true;
        }
    }

    public void EnableAndDisableMovement()
    {
        if (canMove == true)
        {
            canMove = false;
        }

        else if (canMove == false)
        {
            canMove = true;
        }
    }
}
