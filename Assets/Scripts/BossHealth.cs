using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealth : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;
    public float health;
    private float maxHealth;

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        maxHealth = health;
    }

    private void FixedUpdate()
    {
        if ((health / maxHealth) <= 0.25f)
            _spriteRenderer.color = Color.red;
        else if((health / maxHealth) <= 0.5f)
            _spriteRenderer.color = Color.yellow;
        else
            _spriteRenderer.color = Color.white;
    }

    public void TakeDamage(float dmgAmount)
    {
        health -= dmgAmount;
        if (health <= 0)
        {
            StartCoroutine(Die());
        }
        else
            StartCoroutine(Damaged());
    }

    private IEnumerator Die()
    {
        // Bunch of explosions

        yield return new WaitForSeconds(2f);
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
