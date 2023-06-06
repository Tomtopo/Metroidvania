using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D playerCollider;
    private SpriteRenderer _spriteRenderer;
    public PlayerInputActions inputAction;

    [SerializeField] private float speed = 10f;
    [SerializeField] private float jumpForce = 1f;
    [SerializeField] private bool _isGrounded;
    [SerializeField] private bool _isWalled;
    [SerializeField] private bool _isCrouching = false;

    [SerializeField] private float maxVelocity;
    [SerializeField] private Vector2 playerVelocity;

    private float coyoteTime = 0.2f;
    [SerializeField] private float coyoteTimeCounter;

    private float jumpBufferTime = 0.2f;
    [SerializeField] private float jumpBufferCounter;
    public float distToGround;
    public float moveVal;
    public float jumpVal;
    public float crouchVal;

    private void Awake()
    {
        inputAction = new PlayerInputActions();
    }
    // Start is called before the first frame update
    void Start()
    {
        inputAction.Movement.Jump.started += Jump_started;
        inputAction.Movement.Jump.performed += Jump_performed;
        inputAction.Movement.Jump.canceled += Jump_canceled;
        rb = gameObject.GetComponent<Rigidbody2D>();
        playerCollider = gameObject.GetComponent<BoxCollider2D>();
        _spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        distToGround = playerCollider.bounds.extents.y;
    }

    // Update is called once per frame
    void Update()
    {
        // Information
        playerVelocity = rb.velocity;
        _isGrounded = Physics2D.Raycast(transform.position, Vector2.down, distToGround + 0.1f, LayerMask.GetMask("Ground"));
        _isWalled = Physics2D.BoxCast(transform.position, new Vector2(1.2f, 1.8f), 0, new Vector2(0,0), 0, LayerMask.GetMask("Ground"));

        Flip();

        jumpBufferCounter -= Time.deltaTime;


        if (IsGrounded())
        {
            coyoteTimeCounter = coyoteTime;
        }
        else
        {
            coyoteTimeCounter -= Time.deltaTime;
        }

        if(!IsWalled())
            rb.velocity = new Vector2(moveVal * speed, rb.velocity.y);

    }

    // First frame of the jump.
    private void Jump_started(InputAction.CallbackContext obj)
    {
        jumpBufferCounter = jumpBufferTime;
    }

    // Frames during the jump.
    private void Jump_performed(InputAction.CallbackContext obj)
    {
        // Add jumpforce to the player as long as the jump button is pressed.
        if (coyoteTimeCounter > 0f && jumpBufferCounter > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);

            jumpBufferCounter = 0f;
        }
    }

    // Jump button is released.
    private void Jump_canceled(InputAction.CallbackContext context)
    {
        // Start dropping the player if they release the jump button.
        if (rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
            coyoteTimeCounter = 0f;
        }
    }


    public void Move(InputAction.CallbackContext value)
    {
        moveVal = value.ReadValue<float>();
        
    }

    public void Jump(InputAction.CallbackContext value)
    {
        //jumpVal = value.ReadValue<float>();

    }

    public void Crouch(InputAction.CallbackContext value)
    {
        crouchVal = value.ReadValue<float>();
        if(!_isCrouching)
        {
            playerCollider.size = new Vector2(1.2f, 1.35f);
            speed = 5f;
            inputAction.Movement.Jump.Disable();
            _isCrouching = true;
        }
    }
    public void StandUp(InputAction.CallbackContext value)
    {
        if(_isCrouching)
        {
            playerCollider.size = new Vector2(1.2f, 2.7f);
            speed = 10f;
            inputAction.Movement.Jump.Enable();
            _isCrouching = false;
        }
    }

    // Flip the character sprite.
    private void Flip()
    {
        //if (moveVal > 0f)
        //    _spriteRenderer.flipX = false;
        //else if (moveVal < 0f)
        //    _spriteRenderer.flipX = true;
        if(moveVal != 0f)
            transform.localScale = new Vector2(moveVal, transform.localScale.y);
    }

    private bool IsGrounded()
    {
        return Physics2D.Raycast(transform.position, Vector2.down, distToGround + 0.05f, LayerMask.GetMask("Ground"));

    }

    // Is player facing a wall? If the player is crouching, shrink the box size accouring to the collider.
    private bool IsWalled()
    {
        if(_isCrouching)
            return Physics2D.BoxCast(transform.position, new Vector2(1.2f, 1.1f), 0, new Vector2(0, 0), 0, LayerMask.GetMask("Ground"));
        else
            return Physics2D.BoxCast(transform.position, new Vector2(1.2f, 2.5f), 0, new Vector2(0, 0), 0, LayerMask.GetMask("Ground"));
    }

    private void OnEnable()
    {
        inputAction.Enable();
    }

    private void OnDisable()
    {
        inputAction.Disable();
    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        // Draw wallcheck gizmos.
        if(_isCrouching)
            Gizmos.DrawWireCube(transform.position, new Vector3(1.2f, 1.1f, 0));
        else
            Gizmos.DrawWireCube(transform.position, new Vector3(1.2f, 2.5f, 0));
    }

}
