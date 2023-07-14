using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Windows;

public class PlayerBaseState : BaseState
{
    protected Player Player;
    protected static Vector3 MoveInput;
    protected static bool JumpInput;
    protected static float CurrentSpeed;

    private Vector2 _rawInput;

    public PlayerBaseState(Player player)
    {
        Player = player;
        MoveInput = Vector3.zero;
        JumpInput = false;
    }

    public override void Enter()
    {
        InputChannel.MoveEvent += OnMove;
        InputChannel.JumpEvent += OnJump;
    }

    public override void Exit()
    {
        InputChannel.MoveEvent -= OnMove;
        InputChannel.JumpEvent -= OnJump;
    }

    public override void LogicUpdate()
    {
    }

    // Receive inputs from InputManager
    public void OnMove(InputAction.CallbackContext context)
    {
        CalculateMoveVector(context.ReadValue<Vector2>());
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            JumpInput = true;
        }
        else if (context.canceled)
        {
            JumpInput = false;
        }
    }

    public void CalculateMoveVector(Vector2 rawInput)
    {
        Vector3 camVectorRight = Player.Cam.transform.right;
        Vector3 camVectorForward = Player.Cam.transform.forward;

        camVectorForward.y = 0;
        camVectorRight.y = 0;

        Vector3 relRight = camVectorRight.normalized * rawInput.x;
        Vector3 relForward = camVectorForward.normalized * rawInput.y;
        MoveInput = (relRight + relForward).normalized;
        MoveInput.y = 0;
    }

    // Movement
    public void PlayerMovement()
    {
        // Calculate desired velocity
        float targetVelocity = MoveInput.magnitude * Player.MoveSpeed;

        // Find diff between desired velocity and current velocity
        float velocityDif = targetVelocity - Player.Rb.velocity.magnitude;

        // Check whether to accel or deccel
        float accelRate = (Mathf.Abs(targetVelocity) > 0.01f) ? Player.MoveAccel :
            Player.MoveDecel;

        // Calc force by multiplying accel and velocity diff, and applying velocity power
        float movementForce = Mathf.Pow(Mathf.Abs(velocityDif) * accelRate, Player.VelocityPower)
            * Mathf.Sign(velocityDif);

        Player.Rb.AddForce(movementForce * MoveInput);
    }

    public void PlayerAirMovement()
    {
        Player.Rb.AddForce(MoveInput, ForceMode.Force);
    }

    public void PlayerRotation()
    {
        if (MoveInput.magnitude != 0)
        {
            Player.Rb.MoveRotation(Quaternion.LookRotation(MoveInput, Vector3.up));
        }
    }

    public void Jump()
    {
        Vector3 jumpVector = Vector3.up;
        float jumpForce = Mathf.Sqrt(Player.JumpHeight * Physics.gravity.y * -2) * Player.Rb.mass;
        Player.Rb.AddForce(jumpVector * jumpForce, ForceMode.Impulse);
        Debug.Log(jumpForce);
    }

    public bool IsGrounded()
    {
        return Physics.BoxCast(Player.gameObject.transform.position, 
            Player.GroundCheckCol.bounds.extents * 2, Vector3.down,
            out RaycastHit hit, Player.transform.rotation, 0.16f, LayerMask.GetMask("Walkable"));
    }
}
