using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State : MonoBehaviour
{

    protected StateMachine stateMachine;
    protected Actor actor;

    public List<StateTransition> transitions { get; protected set; } = new List<StateTransition>();

    public virtual void OnLoad()
    {
        stateMachine = GetComponentInParent<StateMachine>();
        actor = stateMachine.actor;
        // carregamento base que todo estado deve ter.
    }

    protected void AddTransition(Func<bool> Condition, State target)
    {
        StateTransition transition = new StateTransition(Condition, target);
        AddTransition(transition);
    }

    protected void AddTransition(StateTransition transition)
    {
        transitions.Add(transition);
    }

    public abstract void OnEnter();
    public abstract void OnExit();
    public abstract void Tick();
    public abstract void LateTick();
    public abstract void FixedTick();
}
