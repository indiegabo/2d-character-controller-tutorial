using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateTransition
{
    public Func<bool> Condition;
    public State target;

    public StateTransition(Func<bool> Condition, State target)
    {
        this.Condition = Condition;
        this.target = target;
    }
}
