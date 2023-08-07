using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BossOneController : MonoBehaviour
{
    public Transform target;
    private Rigidbody2D _rb;
    [SerializeField] private BoxCollider2D _bossCollider;

    [SerializeField] private Vector2 _groundCheck;


    [SerializeField] private float _strength = 5f;
    [SerializeField] private float _moveSpeed = 10f;
    [SerializeField] private float _jumpHeight = 10f;
    [SerializeField] private float _phase = 1f;
    [SerializeField] private float _jumpTime = 0f;

    [SerializeField] private bool _movingRight = true;
    [SerializeField] private bool _moving = false;
    [SerializeField] private bool _coroutineIsRunning;


    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();   
        _bossCollider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!_coroutineIsRunning)
        {
            //Move();
            //Flip();
            Jump();
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

    private void Flip()
    {
        if (_movingRight)
            transform.localScale = new Vector2(5, transform.localScale.y);
        else
            transform.localScale = new Vector2(-5, transform.localScale.y);
    }

    public bool IsGrounded()
    {
        return Physics2D.BoxCast(transform.position + (Vector3.down * (_bossCollider.size.y * transform.localScale.x) / 2), new Vector2(_bossCollider.size.x * transform.localScale.x, _groundCheck.y), 0, Vector2.zero, 0, LayerMask.GetMask("Ground", "Slope"));
    }

    private IEnumerator MoveOneStep()
    {
        _coroutineIsRunning = true;
        _moving = true;
        transform.Translate(new Vector2(_moveSpeed * transform.localScale.x * Time.deltaTime, 0), Space.World);
        yield return new WaitForSeconds(1f);
        _moving = false;
        _coroutineIsRunning = false;
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

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(transform.position + (Vector3.down * (_bossCollider.size.y * transform.localScale.x) / 2), new Vector2(_bossCollider.size.x * transform.localScale.x, _groundCheck.y));
    }
}
