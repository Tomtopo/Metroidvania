using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private BoxCollider2D playerCollider;
    private SpriteRenderer _spriteRenderer;
    public PlayerInputActions inputAction;
    private PlayerWeapon _weapon;
    private PlayerHealth _health;
    private Animator _animator;


    [SerializeField] private float speed = 10f;
    [SerializeField] private float runSpeed = 10f;
    [SerializeField] private float crouchSpeed = 5f;
    [SerializeField] private float crawlSpeed = 3f;
    [SerializeField] private float speedCounter;
    [SerializeField] private float jumpForce = 1f;
    [SerializeField] private float _accelerationOnGround = 50f;
    [SerializeField] private float _accelerationInAir = 10f;
    [SerializeField] private Vector2 _moveDirection;
    [SerializeField] private bool _isGrounded;
    [SerializeField] private bool _isWalled;
    [SerializeField] private bool _isOnSlope;
    [SerializeField] private bool _isCrouching = false;
    [SerializeField] private bool _isCrawling = false;

    [SerializeField] private float maxVelocity;
    [SerializeField] private Vector2 playerVelocity;
    [SerializeField] private Vector2 _wallCheck = new Vector2(1.2f, 2.5f);
    [SerializeField] private Vector2 _groundCheck = new Vector2(1f, 0.4f);
    [SerializeField] private Vector2 _wallCheckOffset = new Vector2(0.2f, 0f);
    [SerializeField] private Vector2 _groundCheckOffset = new Vector2(0f, -1f);

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
        inputAction.Movement.Crouch.started += Crouch_started;
        inputAction.Movement.Crouch.canceled += Crouch_canceled;
        inputAction.Movement.Crawl.started += Crawl_started;
        inputAction.Movement.StandUp.started += StandUp_started;

        rb = gameObject.GetComponent<Rigidbody2D>();
        playerCollider = gameObject.GetComponent<BoxCollider2D>();
        _spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        distToGround = playerCollider.bounds.extents.y;
        _weapon = GetComponent<PlayerWeapon>();
        _health = GetComponent<PlayerHealth>();
        _animator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
        // Information
        playerVelocity = rb.velocity;
        _isGrounded = IsGrounded();
        _isWalled = IsWalled();
        _isOnSlope = IsOnSlope();
        //_isWalled = Physics2D.BoxCast(transform.position, new Vector2(1.2f, 1.8f), 0, new Vector2(0,0), 0, LayerMask.GetMask("Ground"));
        Flip();

        jumpBufferCounter -= Time.deltaTime;


        if (IsGrounded())
        {
            coyoteTimeCounter = coyoteTime;
            _animator.SetBool("Jump", false);
        }
        else
        {
            coyoteTimeCounter -= Time.deltaTime;
        }


        if (!IsGrounded())
        {
            _animator.SetBool("Run", false);
            _animator.SetBool("Idle", false);
            _animator.SetBool("Jump", true);
        }

        if (moveVal != 0 && !_animator.GetBool("Jump"))
        {
            _animator.SetBool("Run", true);
            _animator.SetBool("Idle", false);
        }
        else if (moveVal == 0 && !_animator.GetBool("Jump"))
        {
            _animator.SetBool("Run", false);
            _animator.SetBool("Idle", true);
        }

        if(IsOnSlope())
        {
            rb.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
        }
        else
        {
            rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        }

        Acceleration();


        // Moves the player.
        if (!IsWalled() && _weapon.turretModeVal == 0)
        {
            //rb.velocity = new Vector2(moveVal * speed, rb.velocity.y);
            CalculateTranslationDirection();
            transform.Translate(new Vector2(_moveDirection.x * speedCounter * Time.deltaTime, _moveDirection.y * speedCounter * Time.deltaTime), Space.World);
        }


    }

    void CalculateTranslationDirection()
    {
        if (IsGrounded())
        {
            RaycastHit2D ray = Physics2D.Raycast(new Vector2(transform.position.x + transform.localScale.x / 2, transform.position.y), Vector2.down, Mathf.Infinity, LayerMask.GetMask("Ground", "Wall", "Slope"));
            _moveDirection = ray.normal;
            _moveDirection = Quaternion.AngleAxis(90f, Vector3.back) * _moveDirection;
        }
        else
        {
            _moveDirection = new Vector2(1f, 0f);
        }

    }

    // First frame of the jump. Changes the player collider size in case the jump starts from crouch position.
    private void Jump_started(InputAction.CallbackContext obj)
    {
        jumpBufferCounter = jumpBufferTime;
        playerCollider.size = new Vector2(0.95f, 2.7f);
        playerCollider.offset = new Vector2(0f, 0f);
        speed = runSpeed;
        //inputAction.Movement.Jump.Enable();
        _isCrouching = false;
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
        jumpVal = value.ReadValue<float>();
    }

    public void Crouch(InputAction.CallbackContext value)
    {
        // Only enables crouching if the player isn't moving.
        if(!_isCrouching && moveVal == 0)
            crouchVal = value.ReadValue<float>();
    }
    public void StandUp(InputAction.CallbackContext value)
    {

    }

    public void Crawl(InputAction.CallbackContext value)
    {

    }

    private void StandUp_started(InputAction.CallbackContext obj)
    {
        StartCoroutine(RiseUp());
    }

    private void Crouch_canceled(InputAction.CallbackContext value)
    {
        //_isCrouching = true;
        crouchVal = value.ReadValue<float>();
    }

    // Crawling disables jump and shoot inputs and changes the player collider size to smaller.
    private void Crawl_started(InputAction.CallbackContext obj)
    {
        if (_isCrouching && crouchVal == 0 && !_weapon.turretModeEnabled && moveVal == 0)
        {
            playerCollider.size = new Vector2(0.95f, 0.95f);
            //playerCollider.offset = new Vector2(0f, 1f);
            speed = crawlSpeed;
            inputAction.Movement.Jump.Disable();
            //jumpForce = 0f;
            inputAction.Movement.Shoot.Disable();
            _isCrawling = true;
        }
    }

    private void Crouch_started(InputAction.CallbackContext obj)
    {
        if (!_isCrouching && moveVal == 0)
        {
            _isCrouching = true;
            playerCollider.size = new Vector2(0.95f, 1.7f);
            //playerCollider.offset = new Vector2(0f, 0.5f);
            speed = crouchSpeed;
        }
    }

    // Accelerates player when they start moving and stop moving and they have a momentum.
    private void Acceleration()
    {
        // On ground acceleration.
        if(IsGrounded())
        {
            if (moveVal == 1)
            {
                speedCounter += Time.deltaTime * _accelerationOnGround;
            }
            else if (moveVal == -1)
                speedCounter -= Time.deltaTime * _accelerationOnGround;
            else if (moveVal == 0)
            {
                if (speedCounter > 0)
                {
                    speedCounter -= Time.deltaTime * _accelerationOnGround;
                    if (speedCounter < 0)
                        speedCounter = 0;
                }
                else if (speedCounter < 0)
                {
                    speedCounter += Time.deltaTime * _accelerationOnGround;
                    if (speedCounter > 0)
                        speedCounter = 0;
                }

            }
            if (speedCounter > speed)
                speedCounter = speed;
            else if (speedCounter < -speed)
                speedCounter = -speed;
        }
        // Jumping horizontal acceleration.
        else
        {
            if (moveVal == 1)
            {
                speedCounter += Time.deltaTime * _accelerationInAir;
            }
            else if (moveVal == -1)
                speedCounter -= Time.deltaTime * _accelerationInAir;
            else if (moveVal == 0)
            {
                if (speedCounter > 0)
                {
                    speedCounter -= Time.deltaTime * _accelerationInAir;
                    if (speedCounter < 0)
                        speedCounter = 0;
                }
                else if (speedCounter < 0)
                {
                    speedCounter += Time.deltaTime * _accelerationInAir;
                    if (speedCounter > 0)
                        speedCounter = 0;
                }

            }
            if (speedCounter > speed)
                speedCounter = speed;
            else if (speedCounter < -speed)
                speedCounter = -speed;
        }
    }

    // Flip the character sprite.
    private void Flip()
    {
        if(moveVal != 0f)
            transform.localScale = new Vector2(moveVal, transform.localScale.y);
    }

    public bool IsGrounded()
    {
        //return Physics2D.Raycast(transform.position, Vector2.down, distToGround + 0.05f, LayerMask.GetMask("Ground"));
        return Physics2D.BoxCast(transform.position + (Vector3.down * playerCollider.size.y / 2), new Vector2(playerCollider.size.x, _groundCheck.y), 0, Vector2.zero, 0, LayerMask.GetMask("Ground", "Slope"));

    }

    public bool IsOnSlope()
    {
        //return Physics2D.Raycast(transform.position, Vector2.down, distToGround + 0.05f, LayerMask.GetMask("Ground"));
        return Physics2D.BoxCast(transform.position + (Vector3.down * playerCollider.size.y / 2), new Vector2(playerCollider.size.x, _groundCheck.y), 0, Vector2.zero, 0, LayerMask.GetMask("Slope"));

    }

    // Is player facing a wall? If the player is crouching or crawling, shrink the box size accouring to the collider.
    private bool IsWalled()
    {
        if (_isCrawling)
            return Physics2D.BoxCast(new Vector2(transform.position.x + (_wallCheckOffset.x * transform.localScale.x), transform.position.y + _wallCheckOffset.y), new Vector2(_wallCheck.x, 0.5f), 0, new Vector2(0, 0), 0, LayerMask.GetMask("Wall", "Ground"));
        else if (_isCrouching)
            return Physics2D.BoxCast(new Vector2(transform.position.x + (_wallCheckOffset.x * transform.localScale.x), transform.position.y + _wallCheckOffset.y), new Vector2(_wallCheck.x, 1.1f), 0, new Vector2(0, 0), 0, LayerMask.GetMask("Wall", "Ground"));
        else
            return Physics2D.BoxCast(new Vector2(transform.position.x + (_wallCheckOffset.x * transform.localScale.x), transform.position.y + _wallCheckOffset.y), new Vector2(_wallCheck.x, _wallCheck.y), 0, new Vector2(0, 0), 0, LayerMask.GetMask("Wall", "Ground"));
    }

    private bool CeilingCheck()
    {
        if(_isCrawling)
            return Physics2D.BoxCast(new Vector2(transform.position.x, transform.position.y + playerCollider.size.y / 2), new Vector2(0.9f, 0.5f), 0, new Vector2(0, 0), 0, LayerMask.GetMask("Ground"));
        else
            return Physics2D.BoxCast(new Vector2(transform.position.x, transform.position.y + playerCollider.size.y / 2), new Vector2(0.9f, 0.5f), 0, new Vector2(0, 0), 0, LayerMask.GetMask("Ground"));
    }

    // Enumerator to standing up from crouching position. Enlarges player collider size step by step. Without might cause clipping into ground when doing in certain positions.
    public IEnumerator RiseUp()
    {
        if (_isCrawling && !CeilingCheck())
        {
            while(playerCollider.size.y < 1.7f)
            {
                playerCollider.size += new Vector2(0, Time.deltaTime * 10f);
                yield return new WaitForSeconds(Time.deltaTime);
            }
            playerCollider.size = new Vector2(0.95f, 1.7f);

            speed = crouchSpeed;
            inputAction.Movement.Jump.Enable();
            //jumpForce = 25f;
            inputAction.Movement.Shoot.Enable();
            _isCrawling = false;
        }
        else if (_isCrouching && !CeilingCheck())
        {
            while (playerCollider.size.y < 2.7f)
            {
                playerCollider.size += new Vector2(0, Time.deltaTime * 10f);
                yield return new WaitForSeconds(Time.deltaTime);
            }
            playerCollider.size = new Vector2(0.95f, 2.7f);

            //playerCollider.offset = new Vector2(0f, 0f);
            speed = runSpeed;
            //inputAction.Movement.Jump.Enable();
            _isCrouching = false;

        }
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
        Gizmos.color = Color.green;
        Gizmos.DrawLine(new Vector2(transform.position.x + transform.localScale.x / 2, transform.position.y), new Vector2(transform.position.x + transform.localScale.x / 2, transform.position.y - 20f));
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(transform.position + (Vector3.down * playerCollider.size.y / 2), new Vector2(playerCollider.size.x, _groundCheck.y));
        if(_isCrawling)
            Gizmos.DrawWireCube(new Vector2(transform.position.x, transform.position.y + playerCollider.size.y / 2), new Vector2(0.9f, 0.5f));
        else if(_isCrouching)
            Gizmos.DrawWireCube(new Vector2(transform.position.x, transform.position.y + playerCollider.size.y / 2), new Vector2(0.9f, 0.5f));
        Gizmos.color = Color.yellow;
        // Draw wallcheck gizmos.
        if(_isCrawling)
            Gizmos.DrawWireCube(new Vector2(transform.position.x + (_wallCheckOffset.x * transform.localScale.x), transform.position.y + _wallCheckOffset.y), new Vector2(_wallCheck.x, 0.45f));
        else if (_isCrouching)
            Gizmos.DrawWireCube(new Vector2(transform.position.x + (_wallCheckOffset.x * transform.localScale.x), transform.position.y + _wallCheckOffset.y), new Vector2(_wallCheck.x, 1f));
        else
            Gizmos.DrawWireCube(new Vector2(transform.position.x + (_wallCheckOffset.x * transform.localScale.x), transform.position.y + _wallCheckOffset.y), new Vector2(_wallCheck.x, _wallCheck.y));
    }

}
