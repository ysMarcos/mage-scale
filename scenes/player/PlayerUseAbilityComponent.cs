using Godot;
using System;

[GlobalClass]
public partial class PlayerUseAbilityComponent : Node2D
{
    [Export] public String UseActionName = "shoot";
    [Export] Ability Ability;
    [Export] Node2D User;

    public override void _Input(InputEvent @event)
    {
        if(@event.IsActionPressed(UseActionName))
        {
            Ability.Use(User);
        }
    }
}
