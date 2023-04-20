using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Stats
    [SerializeField] private float _moveForce;
    [SerializeField] private float _targetVelocity;

    // Inputs
    private float _horizontalInput;
    private float _verticalInput;
    
    // Components
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        PlayerInput();
    }

    void FixedUpdate()
    {
        PlayerMovement();
        Debug.Log(rb.velocity.magnitude);
    }

    void PlayerInput()
    {
        _horizontalInput = Input.GetAxisRaw("Horizontal");
        _verticalInput = Input.GetAxisRaw("Vertical");
    }

    void PlayerMovement()
    {
        Vector3 moveDir = new Vector3(_horizontalInput, 0, _verticalInput).normalized;

        if (rb.velocity.magnitude < _targetVelocity)
        {
            rb.AddForce(moveDir * _moveForce, ForceMode.Acceleration);
        }
    }
}
