using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunningState : State
{
    protected Character character => actor as Character;

    Func<bool> Idle => () => character.characterInput.movement.x == 0;

    public override void OnLoad()
    {
        base.OnLoad();

        AddTransition(Idle, GetComponent<IdleState>());
    }

    public override void OnEnter()
    {
        character.animator.SetBool("Running", true);
    }

    public override void OnExit()
    {
        character.animator.SetBool("Running", false);
    }

    public override void Tick()
    {
        // Debug.Log("Tick Running");
    }

    public override void LateTick()
    {
        // Debug.Log("LateTick Running");
    }

    public override void FixedTick()
    {
        character.rb.velocity = new Vector2(character.characterInput.movement.x * character.speed, character.rb.velocity.y);
    }
}
