using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerWeapon : MonoBehaviour
{

    [SerializeField] private GameObject _projectile;
    private PlayerController _playerController;

    PlayerInputActions inputAction;
    PlayerInput pi;

    public bool isAimingUp = false;
    public bool isAimingDown = false;
    public bool isAimingUpCorner = false;
    public bool isAimingDownCorner = false;
    public bool turretModeEnabled = false;

    public float _shootCooldown;
    private float _shootCooldownCounter;

    public float turretModeVal;
    public float aimingUpVal;
    public float aimingDownVal;
    public float aimingUpCornerVal;
    public float aimingDownCornerVal;


    private void Start()
    {
        _playerController = GetComponent<PlayerController>();
        inputAction = _playerController.inputAction;
        inputAction.Movement.Shoot.started += Shoot_started;
        pi = GetComponent<PlayerInput>();
    }

    // When shoot button is pressed, instantiates a projectile to a position relative to player where they're aiming.
    private void Shoot_started(InputAction.CallbackContext obj)
    {
        if(_shootCooldownCounter <= 0f)
        {
            // Saves bool values to temporary variables in case the boolean values are changed during the frame. (not sure if neccessary)
            bool tempisAimingUp = isAimingUp;
            bool tempisAimingDown = isAimingDown;
            bool tempisAimingUpCorner = isAimingUpCorner;
            bool tempisAimingDownCorner = isAimingDownCorner;

            if (tempisAimingUpCorner)
            {
                //Debug.Log("ShootUpCorner");
                Instantiate(_projectile, new Vector2(transform.position.x + transform.localScale.x, transform.position.y + 1.3f), Quaternion.identity);
                _shootCooldownCounter = _shootCooldown;
            }
            else if (tempisAimingUp)
            {
                //Debug.Log("ShootUp");
                Instantiate(_projectile, new Vector2(transform.position.x, transform.position.y + 1.5f), Quaternion.identity);
                _shootCooldownCounter = _shootCooldown;
            }
            else if (tempisAimingDown)
            {
                //Debug.Log("ShootDown");
                Instantiate(_projectile, new Vector2(transform.position.x, transform.position.y - 1.5f), Quaternion.identity);
                _shootCooldownCounter = _shootCooldown;
            }
            else if (tempisAimingDownCorner)
            {
                //Debug.Log("ShootDownCorner");
                Instantiate(_projectile, new Vector2(transform.position.x + transform.localScale.x, transform.position.y - 0.5f), Quaternion.identity);
                _shootCooldownCounter = _shootCooldown;
            }
            else if (!tempisAimingUp && !tempisAimingUpCorner)
            {
                //Debug.Log("ShootDefault");
                Instantiate(_projectile, new Vector2(transform.position.x + transform.localScale.x, transform.position.y + 0.2f), Quaternion.identity);
                _shootCooldownCounter = _shootCooldown;
            }
        }
    }



    // Update is called once per frame
    void Update()
    {
        _shootCooldownCounter -= Time.deltaTime;

        if (aimingUpVal != 0f)
            isAimingUp = true;
        else
            isAimingUp = false;

        if (aimingDownVal != 0f/* && !_playerController.IsGrounded()*/)
            isAimingDown = true;
        else
            isAimingDown = false;

        if (aimingUpCornerVal != 0f || (_playerController.moveVal != 0 && isAimingUp))
        {
            isAimingUpCorner = true;
            isAimingUp = false;
        }
        else
            isAimingUpCorner = false;

        if (aimingDownCornerVal != 0f || (_playerController.moveVal != 0 && isAimingDown))
        {
            isAimingDownCorner = true;
            isAimingDown = false;
        }
        else
            isAimingDownCorner = false;
    }

    public void Shoot(InputAction.CallbackContext value)
    {


    }

    public void AimUp(InputAction.CallbackContext value)
    {
        aimingUpVal = value.ReadValue<float>();

    }


    public void AimUpCorner(InputAction.CallbackContext value)
    {
        aimingUpCornerVal = value.ReadValue<float>();

    }

    public void AimDown(InputAction.CallbackContext value)
    {
        aimingDownVal = value.ReadValue<float>();

    }


    public void AimDownCorner(InputAction.CallbackContext value)
    {
        aimingDownCornerVal = value.ReadValue<float>();

    }

    public void TurretMode(InputAction.CallbackContext value)
    {
        turretModeVal = value.ReadValue<float>();
        if (turretModeVal == 1f)
        {
            Debug.Log("input disabled");
            turretModeEnabled = true;
        }
        else
        {
            Debug.Log("input enabled");
            turretModeEnabled = false;
        }
    }
}
