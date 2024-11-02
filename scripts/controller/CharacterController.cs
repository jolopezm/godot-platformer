using Godot;
using System;
using System.Numerics;
using Vector2 = Godot.Vector2;

public partial class CharacterController : CharacterBody2D
{
    private AnimatedSprite2D animatedSprite2D;
    private HSlider runVelocitySlider;
    private HSlider jumpHeightSlider;
    private HSlider accelerationSlider;
    private HSlider frictionSlider;
    public int score = 0;
    public Vector2 direction;

    [Export(PropertyHint.Range, "0,20,")] public float speed;
    [Export] public float jumpForce;
    [Export] public float acceleration; 
    [Export] public float friction;
    [Export] public float maxJumpTime = 0.5f;
    [Export] public float jumpTime = 0.0f;
    public bool isJumping = false;

    public override void _Ready() 
    {
        animatedSprite2D = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
        runVelocitySlider = GetNode<HSlider>("../GUI/RunVelocitySlider");
        jumpHeightSlider = GetNode<HSlider>("../GUI/JumpHeightSlider");
        accelerationSlider = GetNode<HSlider>("../GUI/AccelerationSlider");
        frictionSlider = GetNode<HSlider>("../GUI/FrictionSlider");
    }

    public override void _PhysicsProcess(double delta)
    {
        Vector2 velocity = Velocity;

        if (!IsOnFloor()) {
            velocity += GetGravity() * (float)delta;
        }

        if (Input.IsActionJustPressed("jump") && IsOnFloor()) {
            isJumping = true;
            jumpTime = 0.0f;
            jumpForce = GetJumpHeight()*2;
            velocity.Y = jumpForce;
        }

        if (isJumping)
        {
            jumpTime += (float)delta*2;
            if (jumpTime < maxJumpTime && Input.IsActionPressed("jump"))
            {
                velocity.Y = GetJumpHeight();
            }
            else
            {
                isJumping = false;
            }
        }

        direction = Input.GetVector("left", "right", "up", "down");
        if (direction != Vector2.Zero) {
            speed = GetSpeed();
            acceleration = GetAcceleration();
            velocity.X = Mathf.MoveToward(velocity.X, direction.X * speed, acceleration * (float)delta);
        }
        else {
            friction = GetFriction();
            velocity.X = Mathf.MoveToward(velocity.X, 0, friction * (float)delta);
        }

        Velocity = velocity;

        ChangeSpriteDirection();
        MoveAndSlide();
    }

    public void ChangeSpriteDirection()
    {
        if (direction.X > 0) {
            animatedSprite2D.FlipH = false;
        }
        else if (direction.X < 0) {
            animatedSprite2D.FlipH = true;
        }

        if (IsOnFloor()) {
            if (Velocity.X != 0) {
                animatedSprite2D.Play("run");
            }
            else {
                animatedSprite2D.Play("idle");
            }
        }
        else {
            animatedSprite2D.Play("jump");
        }
    }

    public void SetScore(int value) {
        score = score + value;
    }

    public float GetSpeed() {
        return (float)runVelocitySlider.Value * 3f;
    }

    public float GetJumpHeight() {
        return (float)jumpHeightSlider.Value * -1;
    }

    public float GetAcceleration() {
        return (float)accelerationSlider.Value;
    }

    public float GetFriction() {
        return (float)frictionSlider.Value;
    }
}
