using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D playerCollider;

    [SerializeField] private float speed = 10f;
    [SerializeField] private float jumpForce = 1f;
    [SerializeField] private bool _isGrounded;

    [SerializeField] private float maxVelocity;
    [SerializeField] private float playerVelocity;

    private float coyoteTime = 0.2f;
    private float coyoteTimeCounter;

    private float jumpBufferTime = 0.2f;
    private float jumpBufferCounter;
    public float distToGround;
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        playerCollider = gameObject.GetComponent<BoxCollider2D>();
        distToGround = playerCollider.bounds.extents.y;
    }

    // Update is called once per frame
    void Update()
    {
        playerVelocity = rb.velocity.x;
        _isGrounded = Physics2D.Raycast(transform.position, Vector2.down, distToGround + 0.1f, LayerMask.GetMask("Ground"));
        if(IsGrounded())
        {
            coyoteTimeCounter = coyoteTime;
        }
        else
        {
            coyoteTimeCounter -= Time.deltaTime;
        }

        if(Input.GetKeyDown(KeyCode.Space))
        {
            jumpBufferCounter = jumpBufferTime;
        }
        else
        {
            jumpBufferCounter -= Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.A))
        {
            //rb.AddForce(Vector2.left * speed);
            //transform.Translate(Vector2.left * speed);
            rb.velocity = new Vector2(-speed, rb.velocity.y);
        }
        if (Input.GetKey(KeyCode.D))
        {
            //rb.AddForce(Vector2.right * speed);
            //transform.Translate(Vector2.right * speed);
            rb.velocity = new Vector2(speed, rb.velocity.y);
        }
        if(coyoteTimeCounter > 0f && jumpBufferCounter > 0f)
        {
            //rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);

            jumpBufferCounter = 0f;
        }
        if(Input.GetKeyUp(KeyCode.Space) && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
            coyoteTimeCounter = 0f;
        }

    }

    private bool IsGrounded()
    {
        return Physics2D.Raycast(transform.position, Vector2.down, distToGround + 0.05f, LayerMask.GetMask("Ground"));

    }

}
