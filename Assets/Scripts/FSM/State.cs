using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State : MonoBehaviour
{
    #region State Machine

    private StateMachine _machine;

    public StateMachine machine { get { return _machine; } set { _machine = value; } }

    #endregion

    #region Transitions

    private List<StateTransition> _transitions = new List<StateTransition>();

    public List<StateTransition> transitions => _transitions;

    public void AddTransition(Func<bool> Condition, State targetState)
    {
        StateTransition transition = new StateTransition(Condition, targetState);
        AddTransition(transition);
    }

    public void AddTransition(StateTransition newTransition)
    {
        // StateTransition existentTransition = _transitions.Find(transition => transition.targetState == newTransition.targetState);
        // if (existentTransition != null) return;
        _transitions.Add(newTransition);
    }

    #endregion

    #region Abstractions

    public abstract void Load();

    public abstract void OnEnter();
    public abstract void OnExit();

    public abstract void Tick();
    public abstract void FixedTick();
    public abstract void LateTick();

    #endregion

}
