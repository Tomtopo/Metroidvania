using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BasicEnemyController : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _health;
    private Rigidbody2D rb;

    private float gravityForce = 1f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
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
        if(GroundCheck())
            transform.Translate(transform.right * _speed * Time.deltaTime, Space.World);


    }

    private bool WallCheck()
    {
        return Physics2D.BoxCast(transform.position + (transform.right * 0.05f), new Vector2(transform.localScale.x - 0.1f, transform.localScale.y - 0.1f), 0, new Vector2(0, 0), 0, LayerMask.GetMask("Ground"));
    }

    private bool GroundCheck()
    {
        return Physics2D.BoxCast(transform.position + (-transform.up * 0.05f) + (transform.right * 0.05f), new Vector2(transform.localScale.x, transform.localScale.y), 0, new Vector2(0, 0), 0, LayerMask.GetMask("Ground"));
    }

    //private bool RearGroundCheck()
    //{
    //    return Physics2D.Raycast(transform.position - (transform.right / 2f), -transform.up, (transform.localScale.y / 2f) + 0.2f, LayerMask.GetMask("Ground"));
    //}

    private void TakeDamage()
    {
        _health -= 1f;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.gameObject.layer == LayerMask.NameToLayer("PlayerProjectile"))
        {
            TakeDamage();

            if(_health <= 0f)
                Destroy(gameObject);
        }
    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(transform.position + (transform.right * 0.05f), new Vector2(transform.localScale.x - 0.1f, transform.localScale.y - 0.1f));
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(transform.position + (-transform.up * 0.05f) + (transform.right * 0.05f), new Vector2(transform.localScale.x, transform.localScale.y));
    }
}
