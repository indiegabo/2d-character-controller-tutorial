
public class CharacterState : State
{
    protected Character actor => machine.actor as Character;

    public override void Load() { }

    public override void OnEnter() { }
    public override void OnExit() { }

    public override void Tick() { }
    public override void FixedTick() { }
    public override void LateTick() { }
}