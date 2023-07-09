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
}
