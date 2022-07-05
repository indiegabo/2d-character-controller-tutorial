using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : State
{
    protected Character character => actor as Character;

    Func<bool> Running => () => character.characterInput.movement.x != 0;

    public override void OnLoad()
    {
        base.OnLoad();

        AddTransition(Running, GetComponent<RunningState>());
    }

    public override void OnEnter()
    {
        character.animator.SetBool("Idle", true);
    }

    public override void OnExit()
    {
        character.animator.SetBool("Idle", false);
    }

    public override void Tick()
    {
        // Debug.Log("Tick Idle");
    }

    public override void LateTick()
    {
        // Debug.Log("LateTick Idle");
    }

    public override void FixedTick()
    {
        character.rb.velocity = new Vector2(0, character.rb.velocity.y);
    }
}
