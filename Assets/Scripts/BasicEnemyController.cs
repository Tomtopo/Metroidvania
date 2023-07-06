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
    [SerializeField] private bool isJustInstantiated = true;

    [SerializeField] private Vector2 _offsetGroundCheck;
    [SerializeField] private Vector2 groundCheckSize;
    [SerializeField] private Vector2 _offsetWallCheck;
    [SerializeField] private Vector2 wallCheckSize;
    private float gravityForce = 5f;

    private bool _rotated = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        _health = GetComponent<Health>();
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
                    transform.Translate(transform.right * _speed * Time.deltaTime, Space.World);
                }
                else if(GroundAheadCheck())
                    transform.Translate(transform.right * _speed * Time.deltaTime, Space.World);
            }
            else if (!GroundCheck() && !_rotated)
            {
                transform.Rotate(new Vector3(0, 0, -90f));
                _rotated = true;
            }
            else if (WallCheck())
            {
                transform.Rotate(new Vector3(0, 0, 90f));
            }
            else if (GroundCheck() || GroundAheadCheck())
                transform.Translate(transform.right * _speed * Time.deltaTime, Space.World);
        }



    }

    private bool WallCheck()
    {
        if (transform.eulerAngles.z == 90 || transform.eulerAngles.z == 270)
            return Physics2D.BoxCast(transform.position + (transform.right * _offsetWallCheck.x), new Vector2(transform.localScale.x * wallCheckSize.y, transform.localScale.y * wallCheckSize.x), 0, new Vector2(0, 0), 0, LayerMask.GetMask("Ground"));
        else
            return Physics2D.BoxCast(transform.position + (transform.right * _offsetWallCheck.x), new Vector2(transform.localScale.x * wallCheckSize.x, transform.localScale.y * wallCheckSize.y), 0, new Vector2(0, 0), 0, LayerMask.GetMask("Ground"));
    }

    private bool GroundCheck()
    {
        if(transform.eulerAngles.z == 90 || transform.eulerAngles.z == 270)
            return Physics2D.BoxCast(transform.position + (-transform.up * _offsetGroundCheck.y) + (transform.right * _offsetGroundCheck.x), new Vector2(groundCheckSize.y, groundCheckSize.x), 0, new Vector2(0, 0), 0, LayerMask.GetMask("Ground"));
        else
            return Physics2D.BoxCast(transform.position + (-transform.up * _offsetGroundCheck.y) + (transform.right * _offsetGroundCheck.x), new Vector2(groundCheckSize.x, groundCheckSize.y), 0, new Vector2(0, 0), 0, LayerMask.GetMask("Ground"));
    }

    private bool GroundAheadCheck()
    {
        return Physics2D.Raycast(transform.position + (transform.right * 0.75f), -transform.up * 0.75f, 1f, LayerMask.GetMask("Ground"));
    }

    //private bool RearGroundCheck()
    //{
    //    return Physics2D.Raycast(transform.position - (transform.right / 2f), -transform.up, (transform.localScale.y / 2f) + 0.2f, LayerMask.GetMask("Ground"));
    //}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.gameObject.layer == LayerMask.NameToLayer("PlayerProjectile"))
        {
            _health.TakeDamage(1f);
        }

        if (collision.collider.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            collision.collider.gameObject.GetComponent<PlayerHealth>().TakeDamage(_strength);
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
            collision.gameObject.GetComponent<PlayerHealth>().TakeDamage(_strength);
}
    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        if (transform.eulerAngles.z == 90 || transform.eulerAngles.z == 270)
            Gizmos.DrawWireCube(transform.position + (transform.right * _offsetWallCheck.x), new Vector2(transform.localScale.x * wallCheckSize.y, transform.localScale.y * wallCheckSize.x));
        else
            Gizmos.DrawWireCube(transform.position + (transform.right * _offsetWallCheck.x), new Vector2(transform.localScale.x * wallCheckSize.x, transform.localScale.y * wallCheckSize.y));
        Gizmos.color = Color.blue;
        if (transform.eulerAngles.z == 90 || transform.eulerAngles.z == 270)
            Gizmos.DrawWireCube(transform.position + (-transform.up * _offsetGroundCheck.y) + (transform.right * _offsetGroundCheck.x), new Vector2(groundCheckSize.y, groundCheckSize.x));
        else
            Gizmos.DrawWireCube(transform.position + (-transform.up * _offsetGroundCheck.y) + (transform.right * _offsetGroundCheck.x), new Vector2(groundCheckSize.x, groundCheckSize.y));

        Gizmos.DrawLine(transform.position + (transform.right * 0.75f), transform.position + (transform.right * 0.75f) - (transform.up * 0.75f));
    }
}
