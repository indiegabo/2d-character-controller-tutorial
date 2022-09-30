using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Actor : MonoBehaviour
{
    [SerializeField]
    private StateMachine _stateMachine;

    protected virtual void Awake()
    {
        if (_stateMachine == null)
            _stateMachine = GetComponent<StateMachine>();

        _stateMachine.SetUp(this);
    }

    protected virtual void Update()
    {
        _stateMachine.Tick();
    }

    protected virtual void FixedUpdate()
    {
        _stateMachine.FixedTick();
    }

    protected virtual void LateUpdate()
    {
        _stateMachine.LateTick();
    }

}
