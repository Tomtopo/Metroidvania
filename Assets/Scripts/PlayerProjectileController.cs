using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjectileController : MonoBehaviour
{
    private GameObject _player;
    private PlayerWeapon _weapon;

    private float _shootDirectionX;
    private float _shootDirectionY;

    bool tempisAimingUp;
    bool tempisAimingDown;
    bool tempisAimingUpCorner;
    bool tempisAimingDownCorner;

    [SerializeField] private float _distanceToDestroy = 25f;

    public float playerProjectileSpeed;
    private void Awake()
    {
        _player = GameObject.Find("Player");
        _weapon = _player.GetComponent<PlayerWeapon>();
        tempisAimingUp = _weapon.isAimingUp;
        tempisAimingDown = _weapon.isAimingDown;
        tempisAimingUpCorner = _weapon.isAimingUpCorner;
        tempisAimingDownCorner = _weapon.isAimingDownCorner;

    }

    // Start is called before the first frame update
    void Start()
    {
        if (tempisAimingUpCorner)
        {
            _shootDirectionY = 1f;
            _shootDirectionX = _player.transform.localScale.x;
            playerProjectileSpeed *= 0.75f;
        }
        else if (tempisAimingUp)
        {
            _shootDirectionY = 1f;
            _shootDirectionX = 0f;

        }
        else if (tempisAimingDownCorner)
        {
            _shootDirectionY = -1f;
            _shootDirectionX = _player.transform.localScale.x;
            playerProjectileSpeed *= 0.75f;
        }
        else if (tempisAimingDown)
        {
            _shootDirectionY = -1f;
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

        if(Vector2.Distance(_player.transform.position, transform.position) > _distanceToDestroy)
            Destroy(gameObject);
    }

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    Destroy(gameObject);
    //}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
}
