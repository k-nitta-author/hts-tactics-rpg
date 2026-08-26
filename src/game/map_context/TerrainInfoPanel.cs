using Godot;
using System;

public partial class TerrainInfoPanel : Panel
{

    Label label;
    Label nlabel;
    Label clabel;


    public override void _Ready()
    {
        label = GetNodeOrNull<Label>("Label");
        nlabel = GetNodeOrNull<Label>("Label2");
        clabel = GetNodeOrNull<Label>("Label3");
    }

	public void updateText(Unit unit, byte unitID)
	{
        label.Text = unitID.ToString();
        nlabel.Text = unit.name;
        clabel.Text = Game.class_names[(byte)unit.char_class];

	}



}
