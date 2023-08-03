using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BasicEnemyController : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _strength;
    [SerializeField] private float _gravityForce;
    private Health _health;
    private Rigidbody2D rb;
    private Collider2D _col;
    [SerializeField] private bool isJustInstantiated = true;

    [SerializeField] private Vector2 _offsetGroundCheck;
    [SerializeField] private Vector2 groundCheckSize;
    [SerializeField] private Vector2 _offsetWallCheck;
    [SerializeField] private Vector2 wallCheckSize;
    private float gravityForce = 5f;



    private bool _rotated = false;

    public bool movingLeft;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        _health = GetComponent<Health>();
        _col = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {

        if(isJustInstantiated)
        {
            transform.Translate(-transform.up * _gravityForce * Time.deltaTime, Space.World);
            if (GroundCheck())
                isJustInstantiated = false;
        }
        else
        {
            rb.AddForce(-transform.up * gravityForce * Time.deltaTime);
            if(_rotated)
            {
                if (GroundCheck())
                {
                    _rotated = false;
                    if(movingLeft)
                        transform.Translate(-transform.right * _speed * Time.deltaTime, Space.World);
                    else
                        transform.Translate(transform.right * _speed * Time.deltaTime, Space.World);
                }
                else if(GroundAheadCheck())
                {
                    if(movingLeft)
                        transform.Translate(-transform.right * _speed * Time.deltaTime, Space.World);
                    else
                        transform.Translate(transform.right * _speed * Time.deltaTime, Space.World);
                }
                    
            }
            else if (!GroundCheck() && !_rotated)
            {
                if(movingLeft)
                    transform.Rotate(new Vector3(0, 0, 90));
                else
                    transform.Rotate(new Vector3(0, 0, -90));
                _rotated = true;
            }
            else if (WallCheck())
            {
                if(movingLeft)
                    transform.Rotate(new Vector3(0, 0, -90));
                else
                    transform.Rotate(new Vector3(0, 0, 90));
            }
            else if (GroundCheck() || GroundAheadCheck())
            {
                if(movingLeft)
                    transform.Translate(-transform.right * _speed * Time.deltaTime, Space.World);
                else
                    transform.Translate(transform.right * _speed * Time.deltaTime, Space.World);
            }
                
        }
        if(CollidedWithPlayer())
        {
            GameObject.Find("Player").GetComponent<PlayerHealth>().TakeDamage(_strength, gameObject);
        }



    }

    private bool WallCheck()
    {
        if(movingLeft)
        {
            if (transform.eulerAngles.z == 90 || transform.eulerAngles.z == 270)
                return Physics2D.BoxCast(transform.position + (-transform.right * _offsetWallCheck.x), new Vector2(transform.localScale.x * wallCheckSize.y, transform.localScale.y * wallCheckSize.x), 0, new Vector2(0, 0), 0, LayerMask.GetMask("Ground"));
            else
                return Physics2D.BoxCast(transform.position + (-transform.right * _offsetWallCheck.x), new Vector2(transform.localScale.x * wallCheckSize.x, transform.localScale.y * wallCheckSize.y), 0, new Vector2(0, 0), 0, LayerMask.GetMask("Ground"));

        }
        else
        {
            if (transform.eulerAngles.z == 90 || transform.eulerAngles.z == 270)
                return Physics2D.BoxCast(transform.position + (transform.right * _offsetWallCheck.x), new Vector2(transform.localScale.x * wallCheckSize.y, transform.localScale.y * wallCheckSize.x), 0, new Vector2(0, 0), 0, LayerMask.GetMask("Ground"));
            else
                return Physics2D.BoxCast(transform.position + (transform.right * _offsetWallCheck.x), new Vector2(transform.localScale.x * wallCheckSize.x, transform.localScale.y * wallCheckSize.y), 0, new Vector2(0, 0), 0, LayerMask.GetMask("Ground"));

        }
    }

    private bool GroundCheck()
    {
        if(movingLeft)
        {
            if (transform.eulerAngles.z == 90 || transform.eulerAngles.z == 270)
                return Physics2D.BoxCast(transform.position + (-transform.up * _offsetGroundCheck.y) + (-transform.right * _offsetGroundCheck.x), new Vector2(groundCheckSize.y, groundCheckSize.x), 0, new Vector2(0, 0), 0, LayerMask.GetMask("Ground"));
            else
                return Physics2D.BoxCast(transform.position + (-transform.up * _offsetGroundCheck.y) + (-transform.right * _offsetGroundCheck.x), new Vector2(groundCheckSize.x, groundCheckSize.y), 0, new Vector2(0, 0), 0, LayerMask.GetMask("Ground"));

        }
        else
        {
            if (transform.eulerAngles.z == 90 || transform.eulerAngles.z == 270)
                return Physics2D.BoxCast(transform.position + (-transform.up * _offsetGroundCheck.y) + (transform.right * _offsetGroundCheck.x), new Vector2(groundCheckSize.y, groundCheckSize.x), 0, new Vector2(0, 0), 0, LayerMask.GetMask("Ground"));
            else
                return Physics2D.BoxCast(transform.position + (-transform.up * _offsetGroundCheck.y) + (transform.right * _offsetGroundCheck.x), new Vector2(groundCheckSize.x, groundCheckSize.y), 0, new Vector2(0, 0), 0, LayerMask.GetMask("Ground"));

        }
    }

    private bool GroundAheadCheck()
    {
        if(movingLeft)
            return Physics2D.Raycast(transform.position + (-transform.right * 0.75f), -transform.up * 0.75f, 1f, LayerMask.GetMask("Ground"));
        else
            return Physics2D.Raycast(transform.position + (transform.right * 0.75f), -transform.up * 0.75f, 1f, LayerMask.GetMask("Ground"));
    }

    //private bool RearGroundCheck()
    //{
    //    return Physics2D.Raycast(transform.position - (transform.right / 2f), -transform.up, (transform.localScale.y / 2f) + 0.2f, LayerMask.GetMask("Ground"));
    //}

    private bool CollidedWithPlayer()
    {
        return Physics2D.BoxCast(transform.position, _col.bounds.size, 0, new Vector2(0,0), 0, LayerMask.GetMask("Player"));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.gameObject.layer == LayerMask.NameToLayer("PlayerProjectile"))
        {
            _health.TakeDamage(1f);
        }

        if (collision.collider.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            collision.collider.gameObject.GetComponent<PlayerHealth>().TakeDamage(_strength, gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == LayerMask.NameToLayer("PlayerProjectile"))
        { 
            _health.TakeDamage(1f);
        }

        if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            collision.gameObject.GetComponent<PlayerHealth>().TakeDamage(_strength, gameObject);
}
    }


    private void OnDrawGizmos()
    {
        if(movingLeft)
        {
            Gizmos.color = Color.yellow;
            if (transform.eulerAngles.z == 90 || transform.eulerAngles.z == 270)
                Gizmos.DrawWireCube(transform.position + (-transform.right * _offsetWallCheck.x), new Vector2(transform.localScale.x * wallCheckSize.y, transform.localScale.y * wallCheckSize.x));
            else
                Gizmos.DrawWireCube(transform.position + (-transform.right * _offsetWallCheck.x), new Vector2(transform.localScale.x * wallCheckSize.x, transform.localScale.y * wallCheckSize.y));
            Gizmos.color = Color.blue;
            if (transform.eulerAngles.z == 90 || transform.eulerAngles.z == 270)
                Gizmos.DrawWireCube((transform.position + (-transform.up * _offsetGroundCheck.y) + -transform.right * _offsetGroundCheck.x), new Vector2(groundCheckSize.y, groundCheckSize.x));
            else
                Gizmos.DrawWireCube((transform.position + (-transform.up * _offsetGroundCheck.y) + -transform.right * _offsetGroundCheck.x), new Vector2(groundCheckSize.x, groundCheckSize.y));

            Gizmos.DrawLine(transform.position + (-transform.right * 0.75f), (transform.position + (-transform.right) * 0.75f) - (transform.up * 0.75f));
        }
        else
        {
            Gizmos.color = Color.yellow;
            if (transform.eulerAngles.z == 90 || transform.eulerAngles.z == 270)
                Gizmos.DrawWireCube(transform.position + (transform.right * _offsetWallCheck.x), new Vector2(transform.localScale.x * wallCheckSize.y, transform.localScale.y * wallCheckSize.x));
            else
                Gizmos.DrawWireCube(transform.position + (transform.right * _offsetWallCheck.x), new Vector2(transform.localScale.x * wallCheckSize.x, transform.localScale.y * wallCheckSize.y));
            Gizmos.color = Color.blue;
            if (transform.eulerAngles.z == 90 || transform.eulerAngles.z == 270)
                Gizmos.DrawWireCube((transform.position + (-transform.up * _offsetGroundCheck.y) + transform.right * _offsetGroundCheck.x), new Vector2(groundCheckSize.y, groundCheckSize.x));
            else
                Gizmos.DrawWireCube((transform.position + (-transform.up * _offsetGroundCheck.y) + transform.right * _offsetGroundCheck.x), new Vector2(groundCheckSize.x, groundCheckSize.y));

            Gizmos.DrawLine(transform.position + (transform.right * 0.75f), (transform.position + transform.right * 0.75f) - (transform.up * 0.75f));
        }

    }
}
