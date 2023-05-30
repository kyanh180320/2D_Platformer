using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    public static PlayerController instance;
    Rigidbody2D rb;
    public float speed;
    public float jumpForce;

    public Transform groundCheckpoint;
    public LayerMask whatIsGround;
    bool isGrounded;
    bool canJumpDouble;

    private Animator anim;
    private SpriteRenderer theSR;

    public float knockBackLength, knockBackForce;
    private float knockBakcCounter;
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        theSR = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (knockBakcCounter <= 0)
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
            else if (rb.velocity.x < 0)
            {
                theSR.flipX = true;
            }
        }
        else
        {
            knockBakcCounter -=Time.deltaTime;
            if (!theSR.flipX)
            {
                rb.velocity = new Vector2(-knockBackForce, rb.velocity.y);
            }
            else
            {
                rb.velocity = new Vector2(knockBackForce, rb.velocity.y);
            }
        }
        
        anim.SetFloat("moveSpeed",Mathf.Abs(rb.velocity.x));
        anim.SetBool("isGrounded", isGrounded);
    }
    public void KnockBack()
    {
        knockBakcCounter = knockBackLength;
        rb.velocity = new Vector2(0, knockBackForce);
    }
}
