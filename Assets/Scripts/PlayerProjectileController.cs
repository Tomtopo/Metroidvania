using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjectileController : MonoBehaviour
{
    private GameObject _player;
    private PlayerWeapon _weapon;
    private float _shootDirectionX;
    private float _shootDirectionY;
    public float playerProjectileSpeed;
    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.Find("Player");
        _weapon = _player.GetComponent<PlayerWeapon>();


        if (_weapon.isAimingUpCorner)
        {
            _shootDirectionY = 1f;
            _shootDirectionX = _player.transform.localScale.x;
        }
        else if (_weapon.isAimingUp)
        {
            _shootDirectionY = 1f;
            _shootDirectionX = 0f;
        }
        else
        {
            _shootDirectionY = 0f;
            _shootDirectionX = _player.transform.localScale.x;
        }
            
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector2(_shootDirectionX * playerProjectileSpeed * Time.deltaTime, _shootDirectionY * playerProjectileSpeed * Time.deltaTime), Space.World);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);
    }
}
