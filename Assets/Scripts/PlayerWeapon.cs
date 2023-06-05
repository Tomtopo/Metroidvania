using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerWeapon : MonoBehaviour
{
    PlayerInputActions inputAction;

    [SerializeField] private GameObject _projectile;
    private void Awake()
    {
        inputAction = new PlayerInputActions();
    }

    // Start is called before the first frame update
    void Start()
    {
        inputAction.Movement.Shoot.started += Shoot_started;
    }

    private void Shoot_started(InputAction.CallbackContext obj)
    {
        Debug.Log("pam");
        Instantiate(_projectile, new Vector2(transform.position.x + transform.localScale.x, transform.position.y + 0.3f), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void InstantiateProjectile(InputAction.CallbackContext context)
    {
        
        //GameObject projectile = Instantiate(_projectile, new Vector2(transform.position.x + transform.localScale.x, transform.position.y + 0.3f), Quaternion.identity);
    }
}
