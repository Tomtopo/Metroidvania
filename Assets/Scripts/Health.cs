using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;
    public float health;

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void TakeDamage(float dmgAmount)
    {
        health -= dmgAmount;
        if (health <= 0)
        {
            Die();
        }
        else
            StartCoroutine(Damaged());
    }

    //private void Damaged()
    //{
    //    _spriteRenderer.enabled = false;
    //}

    private void Die()
    {
        Destroy(gameObject);
    }

    private IEnumerator Damaged()
    {
        _spriteRenderer.enabled = false;
        yield return new WaitForSeconds(0.1f);
        _spriteRenderer.enabled = true;
        yield return new WaitForSeconds(0.1f);

    }

}
