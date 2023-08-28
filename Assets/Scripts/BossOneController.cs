using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BossOneController : MonoBehaviour
{
    public Transform target;
    private Rigidbody2D _rb;
    private BossHealth _health;
    [SerializeField] private BoxCollider2D _bossCollider;

    [SerializeField] private Vector2 _groundCheck;


    [SerializeField] private float _strength = 5f;
    [SerializeField] private float _knockback = 15f;
    [SerializeField] private float _moveSpeed = 10f;
    [SerializeField] private float _jumpHeight = 10f;
    [SerializeField] private float _phase = 1f;
    [SerializeField] private float _jumpTime = 0f;
    [SerializeField] private float _angle;

    [SerializeField] private bool _movingRight = true;
    [SerializeField] private bool _moving = false;
    [SerializeField] private bool _coroutineIsRunning;
    [SerializeField] private string _case = "Move";

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();   
        _bossCollider = GetComponent<BoxCollider2D>();
        _health = GetComponent<BossHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_health.health <= 0)
            StopAllCoroutines();

        Flip();
        if (!_coroutineIsRunning)
        {
            switch (_case)
            {
                case "Move":
                    Move();
                    break;

                case "Jump":
                    Jump();
                    break;

                case "ShootLaser":
                    ShootLaser();
                    break;

                default:
                    _case = "Move";
                    return;
            }
        }
        if (CollidedWithPlayer())
        {
            GameObject.Find("Player").GetComponent<PlayerHealth>().TakeDamage(_strength, gameObject, _knockback);
        }
    }

    private void Move()
    {
        if(!_moving)
            StartCoroutine(MoveOneStep());

    }

    private void Jump()
    {
        if(IsGrounded())
            StartCoroutine(Jumping());
    }

    private void ShootLaser()
    {
        StartCoroutine(LaserBeam());
    }

    private void Flip()
    {
        Vector2 vectorToPlayer = target.transform.position - transform.position;
        _angle = Vector2.Angle(transform.right, vectorToPlayer);
        if (_angle > 90f && !_coroutineIsRunning)
            StartCoroutine(TurnTowardsThePlayer());
    }

    public bool IsGrounded()
    {
        return Physics2D.BoxCast(transform.position + (Vector3.down * (_bossCollider.size.y * transform.localScale.x) / 2), new Vector2(_bossCollider.size.x * transform.localScale.x, _groundCheck.y), 0, Vector2.zero, 0, LayerMask.GetMask("Ground", "Slope"));
    }

    private bool CollidedWithPlayer()
    {
        return Physics2D.BoxCast(transform.position, _bossCollider.bounds.size, 0, new Vector2(0, 0), 0, LayerMask.GetMask("Player"));
    }

    private IEnumerator TurnTowardsThePlayer()
    {
        _coroutineIsRunning = true;
        _case = "Turn";
        yield return new WaitForSeconds(1f);
        transform.Rotate(0f, 180f, 0f);
        _movingRight = !_movingRight;
        yield return new WaitForSeconds(1f);
        _coroutineIsRunning = false;
        _case = "ShootLaser";
    }

    private IEnumerator MoveOneStep()
    {
        _coroutineIsRunning = true;
        _moving = true;
        for(int i = Random.Range(0, 3); i < 4; i++)
        {
            transform.Translate(new Vector2(_moveSpeed * transform.right.x * Time.deltaTime, 0), Space.World);
            yield return new WaitForSeconds(1f);
        }
        _moving = false;
        _coroutineIsRunning = false;
        _case = "Jump";
    }

    private IEnumerator Jumping()
    {
        _coroutineIsRunning = true;
        //_rb.AddForce(new Vector2(target.transform.position.x - transform.position.x, _jumpHeight), ForceMode2D.Impulse);

        Vector2[] point = new Vector2[3];
        point[0] = transform.position;
        point[2] = new Vector2(target.transform.position.x, target.transform.position.y + 1f);
        point[1] = point[0] + (point[2] - point[0]) / 2 + Vector2.up * _jumpHeight;

        while (_jumpTime < 1.0f)
        {
            _jumpTime += 1.5f * Time.deltaTime;

            Vector3 m1 = Vector3.Lerp(point[0], point[1], _jumpTime);
            Vector3 m2 = Vector3.Lerp(point[1], point[2], _jumpTime);
            transform.position = Vector3.Lerp(m1, m2, _jumpTime);

            yield return new WaitForSeconds(Time.deltaTime);
        }
        _jumpTime = 0f;
        yield return new WaitForSeconds(1f);
        _coroutineIsRunning = false;
        _case = "Move";
    }

    private IEnumerator LaserBeam()
    {
        _coroutineIsRunning = true;
        yield return new WaitForSeconds(2f);
        transform.GetChild(2).gameObject.SetActive(true);
        if(Physics2D.BoxCast(new Vector2(transform.position.x + transform.right.x * 15f, transform.position.y), new Vector2(30f, 2f), 0, new Vector2(0, 0), 0, LayerMask.GetMask("Player")))
        {
            GameObject.Find("Player").GetComponent<PlayerHealth>().TakeDamage(_strength, gameObject, _knockback);
            yield return new WaitForSeconds(0.2f);
        }
        transform.GetChild(2).gameObject.SetActive(false);
        yield return new WaitForSeconds(1f);
        _coroutineIsRunning = false;
        _case = "Move";

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.gameObject.layer == LayerMask.NameToLayer("PlayerProjectile") && _health.health > 0f)
        {
            _health.TakeDamage(1f);
        }

        if (collision.collider.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            collision.collider.gameObject.GetComponent<PlayerHealth>().TakeDamage(_strength, gameObject, _knockback);
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.gameObject.layer == LayerMask.NameToLayer("PlayerProjectile") && _health.health > 0f)
        {
            _health.TakeDamage(1f);
        }

        if (collision.collider.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            collision.collider.gameObject.GetComponent<PlayerHealth>().TakeDamage(_strength, gameObject, _knockback);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(transform.position + (Vector3.down * (_bossCollider.size.y * transform.localScale.x) / 2), new Vector2(_bossCollider.size.x * transform.localScale.x, _groundCheck.y));
    }
}
