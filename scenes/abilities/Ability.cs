using Godot;
using System;

[GlobalClass]
public partial class Ability : Resource
{
    public virtual bool Use(Node2D user)
    {
        GD.PushError("Virtual Function - implement in child class");
        return false;
    }
}
