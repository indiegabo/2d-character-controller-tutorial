
using System;
using UnityEngine;

public class CharacterIdleState : CharacterState
{
    private Func<bool> Running => () => actor.characterInput.movement.x != 0;

    public override void Load()
    {
        AddTransition(Running, machine.GetComponent<CharacterRunningState>());
    }

    public override void FixedTick()
    {
        actor.rb.velocity = new Vector2(0, actor.rb.velocity.y);
    }
}