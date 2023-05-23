using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody2D rb;
    public float speed;
    public float jumpForce;
    public Transform groundCheckpoint;
    public LayerMask whatIsGround;
    bool isGrounded;
    bool canJumpDouble;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(speed * Input.GetAxis("Horizontal"), rb.velocity.y);
        isGrounded = Physics2D.OverlapCircle(groundCheckpoint.position, 0.2f, whatIsGround);

        if (Input.GetButtonDown("Jump"))
        {
            if (isGrounded)
            {
                canJumpDouble = true;
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            }
            else
            {
                if (canJumpDouble)
                {
                    rb.velocity = new Vector2(rb.velocity.x, jumpForce);
                    canJumpDouble = false;
                }
            }
        }
    }
}
