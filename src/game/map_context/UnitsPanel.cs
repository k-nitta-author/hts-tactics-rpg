using Godot;

public partial class UnitsPanel : Panel
{

	VBoxContainer vBoxContainer;

    public override void _Ready()
    {
        base._Ready();

		vBoxContainer = GetNodeOrNull<VBoxContainer>("VBoxContainer");
    }


	public void AddUnit(Unit unit)
	{
		UnitPanelComponent upc = (UnitPanelComponent) GD.Load<PackedScene>("uid://bpx7vaops555f").Instantiate();
		vBoxContainer.AddChild(upc);
		upc.Setup(unit);
		
	}

}
