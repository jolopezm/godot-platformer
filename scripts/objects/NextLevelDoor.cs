using Godot;
using System;

public partial class NextLevelDoor : Area2D
{
    [Export]
    PackedScene nextLevel;

    public override void _Ready() {
        BodyEntered += OnDoorBodyEntered;
    }

    public void OnDoorBodyEntered(Node2D body) {
        GetTree().ChangeSceneToPacked(nextLevel);
    }
}
