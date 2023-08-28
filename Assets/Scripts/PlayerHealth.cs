using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;
    public float health;
    public bool invincibilityFrames = false;
    private Rigidbody2D _rb;
    public GameObject _lastDamageSource;

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _rb = GetComponent<Rigidbody2D>();
    }

    public void TakeDamage(float dmgAmount, GameObject damageSource, float damageForce)
    {
        _lastDamageSource = damageSource;
        if (!invincibilityFrames)
        {
            health -= dmgAmount;
            if (health <= 0)
            {
                Die();
            }
            else
                StartCoroutine(Damaged(damageForce));
        }
    }

    //private void Damaged()
    //{
    //    _spriteRenderer.enabled = false;
    //}

    private void Die()
    {
        Destroy(gameObject);
    }

    private IEnumerator Damaged(float damageForce)
    {
        _rb.AddForce((gameObject.transform.position - _lastDamageSource.transform.position).normalized * damageForce, ForceMode2D.Impulse);
        invincibilityFrames = true;
        for (int i = 0; i < 5; i++)
        {
            _spriteRenderer.enabled = false;
            yield return new WaitForSeconds(0.1f);
            _spriteRenderer.enabled = true;
            yield return new WaitForSeconds(0.1f);
        }
        invincibilityFrames = false;
    }
}
