using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Actor : MonoBehaviour
{
    protected StateMachine stateMachine;

    protected virtual void Awake()
    {
        stateMachine = GetComponentInChildren<StateMachine>();

        if (stateMachine != null)
            SetMachine();
    }

    // Método que irá setar a state machine
    protected void SetMachine()
    {
        stateMachine.SetUp(this);
    }

    protected virtual void Update()
    {
        if (stateMachine != null)
            stateMachine.Tick();
    }

    protected void LateUpdate()
    {
        if (stateMachine != null)
            stateMachine.LateTick();
    }

    protected void FixedUpdate()
    {
        if (stateMachine != null)
            stateMachine.FixedTick();
    }
}
