using Godot;
using System;

public partial class Cursor : Sprite2D
{
	public void MoveTo(Vector2 position)
	{
		GlobalPosition = position.Snapped(Game.GRID_SIZE);
	}
}
