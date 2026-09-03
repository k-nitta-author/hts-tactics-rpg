using Godot;

public partial class WalkaroundPlayer : CharacterBody2D
{
	CollisionObject2D collisionObject2D;
	Sprite2D sprite;

	[Export] float speed;

    public override void _PhysicsProcess(double delta)
    {
		Walk();

		MoveAndSlide();
    }

	public void TestForInteraction()
	{
		if (Input.IsActionPressed("walkaroundInteract"))
		{
				
		}
		
	}

	public void Walk()
	{
		float x = Input.GetAxis("walkaroundLeft","walkaroundRight");
		float y = Input.GetAxis("walkaroundUp","walkaroundDown");

		Velocity = new Vector2(x, y) * speed;		
	}

}
