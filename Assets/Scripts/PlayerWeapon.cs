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
    public bool isAimingUpCorner = false;
    public bool turretModeEnabled = false;

    public float _shootCooldown;
    private float _shootCooldownCounter;

    public float turretModeVal;
    public float aimingVal;
    public float aimingUpCornerVal;

    private void Start()
    {
        _playerController = GetComponent<PlayerController>();
        inputAction = _playerController.inputAction;
        pi = GetComponent<PlayerInput>();
    }



    // Update is called once per frame
    void Update()
    {
        _shootCooldownCounter -= Time.deltaTime;

        if (aimingVal != 0f)
            isAimingUp = true;
        else
            isAimingUp = false;

        if (aimingUpCornerVal != 0f || (_playerController.moveVal != 0 && isAimingUp))
        {
            isAimingUpCorner = true;
            isAimingUp = false;
        }
        else
            isAimingUpCorner = false;
    }

    public void InstantiateProjectile(InputAction.CallbackContext value)
    {
        if (_shootCooldownCounter <= 0f && !isAimingUp && !isAimingUpCorner)
        {
            //Debug.Log("ShootDefault");
            Instantiate(_projectile, new Vector2(transform.position.x + transform.localScale.x, transform.position.y + 0.3f), Quaternion.identity);
            _shootCooldownCounter = _shootCooldown;
        }
        else if (_shootCooldownCounter <= 0f && isAimingUpCorner)
        {
            //Debug.Log("ShootUpCorner");
            Instantiate(_projectile, new Vector2(transform.position.x + transform.localScale.x, transform.position.y + 1.5f), Quaternion.identity);
            _shootCooldownCounter = _shootCooldown;
        }
        else if(_shootCooldownCounter <= 0f && isAimingUp)
        {
            //Debug.Log("ShootUp");
            Instantiate(_projectile, new Vector2(transform.position.x, transform.position.y + 2f), Quaternion.identity);
            _shootCooldownCounter = _shootCooldown;
        }

    }

    public void AimUp(InputAction.CallbackContext value)
    {
        aimingVal = value.ReadValue<float>();

    }


    public void AimUpCorner(InputAction.CallbackContext value)
    {
        aimingUpCornerVal = value.ReadValue<float>();

    }

    public void TurretMode(InputAction.CallbackContext value)
    {
        turretModeVal = value.ReadValue<float>();
        //if (turretModeVal == 1f)
        //{
        //    Debug.Log("input disabled");
        //    turretModeEnabled = true;
        //}
        //else
        //{
        //    Debug.Log("input enabled");
        //    turretModeEnabled = false;
        //}
    }
}
