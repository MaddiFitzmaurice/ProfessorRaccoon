using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Variables
    [SerializeField] private float _moveForce;
    [SerializeField] private float _targetVelocity;
    [SerializeField] private Transform _camDir;

    // Inputs
    private Vector3 _moveDir;
    
    // Components
    private Rigidbody _rb;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        PlayerInput();
    }

    void FixedUpdate()
    {
        PlayerMovement();
    }

    void PlayerInput()
    {
        float xInput = Input.GetAxisRaw("Horizontal");
        float zInput = Input.GetAxisRaw("Vertical");

        Vector3 relForward = _camDir.forward * zInput;
        Vector3 relRight = _camDir.right * xInput;

        relForward.y = 0;
        relRight.y = 0;
        
        _moveDir = (relForward + relRight).normalized;

        if (_moveDir.magnitude != 0 )
        {
            transform.rotation = Quaternion.LookRotation(_moveDir, Vector3.up);
        }
    }

    void PlayerMovement()
    {
        if (_rb.velocity.magnitude < _targetVelocity)
        {
            _rb.AddForce(_moveDir * _moveForce, ForceMode.Acceleration);
        }
    }
}
