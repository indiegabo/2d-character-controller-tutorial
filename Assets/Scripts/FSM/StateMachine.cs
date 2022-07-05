using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class StateMachine : MonoBehaviour
{

    [SerializeField]
    protected State defaultState;

    public Actor actor { get; protected set; }
    protected List<State> states = new List<State>();

    protected State currentState;

    protected bool on = false;

    public void SetUp(Actor actor)
    {
        this.actor = actor;
        LoadStates();
        StartMachine();
    }

    protected void LoadStates()
    {
        states = GetComponents<State>().ToList();

        foreach (State state in states)
        {
            state.OnLoad();
        }

        if (defaultState == null)
        {
            ChangeState(states.FirstOrDefault());
        }
        else
        {
            ChangeState(defaultState);
        }

    }

    protected void StartMachine()
    {
        on = true;
    }

    public void Tick()
    {
        HandleTick();
        currentState.Tick();
    }

    public void LateTick()
    {
        HandleTick();
        currentState.LateTick();
    }

    public void FixedTick()
    {
        HandleTick();
        currentState.FixedTick();
    }

    protected void HandleTick()
    {
        if (!on) return;
        State state = EvaluateNextState();
        ChangeState(state);
    }

    protected State EvaluateNextState()
    {
        foreach (StateTransition transition in currentState?.transitions)
        {
            if (transition.Condition())
            {
                return transition.target;
            }
        }

        return null;
    }

    protected void ChangeState(State state)
    {
        if (state == null || currentState == state) return;

        currentState?.OnExit();
        currentState = state;
        currentState?.OnEnter();
    }
}
