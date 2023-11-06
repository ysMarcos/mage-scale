using Godot;
using System;
[GlobalClass]
public partial class ProjectileLaunchAbility : Ability
{
    [Export] public PackedScene ProjectileScene;
    [Export] public Vector2 InstancingOffset;
    public override bool Use(Node2D user)
    {
        Projectile instance = (Projectile)ProjectileScene.Instantiate();
        user.GetParent().AddChild(instance);

        var facingSign = Mathf.Sign(user.GlobalPosition.X);
        var finalOffset = new Vector2(
            InstancingOffset.X * facingSign,
            InstancingOffset.Y
        );

        var instancePosition = user.GlobalPosition + finalOffset;
        instance.GlobalPosition = instancePosition;
        instance.Launch(user, user.GlobalTransform.X);
        return true;
    }
}
