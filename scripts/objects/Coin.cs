using Godot;
using System;

public partial class Coin : Area2D
{
    public int value = 1;
    private AnimatedSprite2D animatedSprite;
    public override void _Ready() {
        animatedSprite = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
        animatedSprite.Play("idle");
    }

    private void OnBodyEntered(Node2D body) {
        CharacterController characterController = GetNode<CharacterController>(body.GetPath());
        characterController.SetScore(value);
        QueueFree();
    }
}
