
using System;
using UnityEngine;

public class CharacterRunningState : CharacterState
{

    private Func<bool> Idle => () => actor.characterInput.movement.x == 0;

    public override void Load()
    {
        AddTransition(Idle, machine.GetComponent<CharacterIdleState>());
    }

    public override void OnEnter()
    {
        actor.animator.SetBool("Running", true);
    }

    public override void OnExit()
    {
        actor.animator.SetBool("Running", false);
    }

    public override void FixedTick()
    {
        float x = actor.xSpeed * actor.characterInput.movement.x;
        float y = actor.rb.velocity.y;

        Vector2 velocity = new Vector2(x, y);

        actor.rb.velocity = velocity;
    }
}