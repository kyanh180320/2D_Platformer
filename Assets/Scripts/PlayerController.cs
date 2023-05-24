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
    private Animator anim;
    private SpriteRenderer theSR;
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        theSR = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
     
        rb.velocity = new Vector2(speed * horizontal, rb.velocity.y);
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
        if (rb.velocity.x > 0)
        {
            theSR.flipX = false;
        }
        else if(rb.velocity.x < 0)
        {
            theSR.flipX =true;
        }
        anim.SetFloat("moveSpeed",Mathf.Abs(rb.velocity.x));
        anim.SetBool("isGrounded", isGrounded);
    }
}
