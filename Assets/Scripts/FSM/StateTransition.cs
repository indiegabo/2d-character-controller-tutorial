using System;

public class StateTransition
{
    #region Fields

    private Func<bool> _Condition;
    private State _targetState;

    #endregion

    #region Getters

    public Func<bool> Condition => _Condition;
    public State targetState => _targetState;

    #endregion

    #region Constructors

    public StateTransition(Func<bool> TransitionCondition, State state)
    {
        _Condition = TransitionCondition;
        _targetState = state;
    }

    #endregion
}
