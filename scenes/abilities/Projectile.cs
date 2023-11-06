using Godot;
using System;

[GlobalClass]
public partial class Projectile : Node2D
{
    [Export] public float Speed = 100f;
    public Vector2 Direction = Vector2.Zero;
    public Node Source;
    public bool launched = false;

    public override void _Ready()
    {
        if(launched == false)
        {
            GD.PushWarning("Projectile created but Launched not called");
        }
    }
    public override void _PhysicsProcess(double delta)
    {
        Position += Direction * Speed * (float)delta;
    }
    
    public void Launch(Node source, Vector2 direction)
    {
        Source = source;
        Direction = direction;
        launched = true;
    }

}
