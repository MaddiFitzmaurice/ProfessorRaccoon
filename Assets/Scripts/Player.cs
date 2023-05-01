using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Data
    public float MoveForce;
    public float TargetVelocity;
    public float JumpIdleForce;
    public float JumpMoveForce;

    // Transform Info
    [HideInInspector] public Vector3 MoveDir;
    public Transform CamDir;
    
    // Components
    [HideInInspector] public Rigidbody Rb;
    [HideInInspector] public BoxCollider Collider;
    public Transform CastPos;

    // State Machine
    private StateMachine _stateMachine;
    public PlayerIdleState IdleState;
    public PlayerMoveState MoveState;
    public PlayerJumpIdleState JumpIdleState;
    public PlayerJumpMoveState JumpMoveState;

    void Awake()
    {
        // State Machine
        IdleState = new PlayerIdleState(this);
        MoveState = new PlayerMoveState(this);
        JumpIdleState = new PlayerJumpIdleState(this);
        JumpMoveState = new PlayerJumpMoveState(this);
        _stateMachine = new StateMachine();
    }

    void Start()
    {
        // Components
        Rb = GetComponent<Rigidbody>();
        Collider = GetComponent<BoxCollider>();

        // Start in idle state
        _stateMachine.ChangeState(IdleState);
    }

    void Update()
    {
        
        _stateMachine.CurrentState.LogicUpdate();
    }

    void FixedUpdate()
    {
        
        _stateMachine.CurrentState.PhysicsUpdate();
    }

    public void ChangeState(BaseState newState)
    {
        _stateMachine.ChangeState(newState);
    }
}
