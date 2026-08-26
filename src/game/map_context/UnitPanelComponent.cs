using Godot;
using System;

public partial class UnitPanelComponent : Control
{


	Label label;
	TextureRect textureRect;

    public override void _Ready()
    {
        label = GetNodeOrNull<Label>("Label");
		textureRect = GetNodeOrNull<TextureRect>("TextureRect");
    }

	public void Setup(Unit unit)
	{
		label.Text = unit.name;
	}
}
