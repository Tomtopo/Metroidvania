using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;
    public float health;
    public bool invincibilityFrames = false;

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void TakeDamage(float dmgAmount)
    {
        if (!invincibilityFrames)
        {
            health -= dmgAmount;
            if (health <= 0)
            {
                Die();
            }
            else
                StartCoroutine(Damaged());
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

    private IEnumerator Damaged()
    {
        invincibilityFrames = true;
        Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Enemy"), LayerMask.NameToLayer("Player"));
        for (int i = 0; i < 5; i++)
        {
            _spriteRenderer.enabled = false;
            yield return new WaitForSeconds(0.1f);
            _spriteRenderer.enabled = true;
            yield return new WaitForSeconds(0.1f);
        }
        invincibilityFrames = false;
        Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Enemy"), LayerMask.NameToLayer("Player"), false);
    }
}
