using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Variables
    public float MoveForce;
    public float TargetVelocity;

    // Transform Info
    [HideInInspector] public Vector3 MoveDir;
    public Transform CamDir;
    
    // Components
    [HideInInspector] public Rigidbody Rb;

    // State Machine
    private StateMachine _stateMachine;
    public PlayerIdleState IdleState;
    public PlayerMoveState MoveState;

    void Awake()
    {
        // State Machine
        IdleState = new PlayerIdleState(this);
        MoveState = new PlayerMoveState(this);
        _stateMachine = new StateMachine();
    }

    void Start()
    {
        Rb = GetComponent<Rigidbody>();
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
