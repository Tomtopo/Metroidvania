using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BasicEnemyController : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _strength;
    private Health _health;
    private Rigidbody2D rb;
    [SerializeField] private bool isJustInstantiated = true;

    [SerializeField] private Vector2 _offsetGroundCheck;
    [SerializeField] private Vector2 groundCheckSize;
    private float gravityForce = 5f;

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
            transform.Translate(-transform.up * _speed * Time.deltaTime, Space.World);
            if (GroundCheck())
                isJustInstantiated = false;
        }
        else
        {
            rb.AddForce(-transform.up * gravityForce * Time.deltaTime);
            if (WallCheck())
            {
                transform.Rotate(new Vector3(0, 0, 90f));
            }
            if (!GroundCheck())
            {
                transform.Rotate(new Vector3(0, 0, -90f));
            }
            if (GroundCheck())
                transform.Translate(transform.right * _speed * Time.deltaTime, Space.World);
        }



    }

    private bool WallCheck()
    {
        return Physics2D.BoxCast(transform.position + (transform.right * 0.05f), new Vector2(transform.localScale.x - 0.1f, transform.localScale.y - 0.1f), 0, new Vector2(0, 0), 0, LayerMask.GetMask("Ground"));
    }

    private bool GroundCheck()
    {
        return Physics2D.BoxCast(transform.position + (-transform.up * _offsetGroundCheck.y) + (transform.right * _offsetGroundCheck.x), new Vector2(groundCheckSize.x, groundCheckSize.y), 0, new Vector2(0, 0), 0, LayerMask.GetMask("Ground"));
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
        Gizmos.DrawWireCube(transform.position + (transform.right * 0.05f), new Vector2(transform.localScale.x - 0.1f, transform.localScale.y - 0.1f));
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(transform.position + (-transform.up * _offsetGroundCheck.y) + (transform.right * _offsetGroundCheck.x), new Vector2(groundCheckSize.x, groundCheckSize.y));
    }
}
