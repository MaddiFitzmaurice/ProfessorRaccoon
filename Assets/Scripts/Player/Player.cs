using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // State Machine + States
    public StateMachine StateMachine { get; private set; }
    public PlayerStateFactory States { get; private set; }

    // Components
    public Rigidbody Rb { get; private set; }
    [Header("Components")]
    public Camera Cam;
    public BoxCollider GroundCheckCol;

    // Data
    [Header("Core Data")]
    public PlayerData WalkData;
    public PlayerData SprintData;

    public float MoveSpeed { get; private set; }
    public float MoveAccel { get; private set; }
    public float MoveDecel { get; private set; }
    public float VelocityPower { get; private set; }
    public float JumpHeight { get; private set; }

    [Header("Additional Data")]
    
    public float SprintTime;
    
    void Awake()
    {
        ComponentSetup();
        StateMachineSetup();
    }

    public void Update()
    {
        StateMachine.CurrentState.LogicUpdate();
    }

    public void FixedUpdate()
    {
        StateMachine.CurrentState.PhysicsUpdate();
    }

    void StateMachineSetup()
    {
        States = new PlayerStateFactory(this);
        StateMachine = new StateMachine(States.IdleState);
    }

    void ComponentSetup()
    {
        Rb = GetComponent<Rigidbody>();
    }

    public void DataChange(PlayerData data)
    {
        MoveSpeed = data.MoveSpeed;
        MoveAccel = data.MoveAccel;
        MoveDecel = data.MoveDecel;
        VelocityPower = data.VelocityPower;
        JumpHeight = data.JumpHeight;
    }
}
