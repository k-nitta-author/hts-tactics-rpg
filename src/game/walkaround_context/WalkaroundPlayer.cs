using Godot;
using System;

public partial class WalkaroundPlayer : CharacterBody2D
{
	CollisionObject2D collisionObject2D;
	Sprite2D sprite;

	[Export] float speed;

	public void walkSpeed(){}

    public override void _PhysicsProcess(double delta)
    {
        base._PhysicsProcess(delta);

		float x = Input.GetAxis("walkaroundLeft","walkaroundRight");
		float y = Input.GetAxis("walkaroundUp","walkaroundDown");

		Velocity = new Vector2(x, y) * speed;

		MoveAndSlide();
    }

}
