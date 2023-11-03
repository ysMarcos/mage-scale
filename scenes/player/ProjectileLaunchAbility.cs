using Godot;
using System;
[GlobalClass]
public partial class ProjectileLaunchAbility : Ability
{
    [Export]
    PackedScene ProjectileScene;
    [Export]
    Vector2 InstanceOffset;
    
    public Boolean Use(Node2D player)
    {
        Projectile instance = (Projectile)ProjectileScene.Instantiate();
        player.GetParent().AddChild(instance);

        var FacingSign = player.direction

        var InstancePosition = player.GlobalPosition + InstanceOffset;
        instance.GlobalPosition = InstancePosition;

        return true;
    }

}
