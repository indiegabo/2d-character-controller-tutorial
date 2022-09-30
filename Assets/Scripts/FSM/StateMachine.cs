using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class StateMachine : MonoBehaviour
{
    #region Inspector

    [SerializeField]
    private State _defaultState;

    [Space]
    [SerializeField]
    public UnityEvent<State> StateChanged;

    #endregion

    #region Configuration

    private Actor _actor;

    private List<State> _states;

    private State _currentState;
    private State _previousState;

    #endregion

    #region  Getters

    public Actor actor => _actor;

    public State currentState => _currentState;
    public State defaultState => _defaultState;

    #endregion

    #region Internal Logic

    public virtual void SetUp(Actor actor)
    {
        _actor = actor;
        LoadStates();
        ChangeState(_defaultState);
    }

    private void LoadStates()
    {
        _states = GetComponents<State>().ToList();

        foreach (State state in _states)
        {
            state.machine = this;
            state.Load();
        }
    }

    private void ChangeState(State newState)
    {
        if (_currentState == newState || newState == null) return;

        _previousState = _currentState;

        _currentState?.OnExit();

        _currentState = newState;

        _currentState.OnEnter();

        StateChanged.Invoke(_currentState);
    }

    private void EvaluateStateChange()
    {
        State state = EvaluateNextState();
        ChangeState(state);
    }

    private State EvaluateNextState()
    {
        if (_currentState == null) return null;

        foreach (StateTransition transition in _currentState?.transitions)
        {
            if (transition.Condition())
            {
                return transition.targetState;
            }
        }

        return null;
    }

    #endregion

    #region Ticks

    public void Tick()
    {
        EvaluateStateChange();
        _currentState?.Tick();
    }

    public void FixedTick()
    {
        EvaluateStateChange();
        _currentState?.FixedTick();
    }

    public void LateTick()
    {
        EvaluateStateChange();
        _currentState?.LateTick();
    }

    #endregion
}
